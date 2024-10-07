using AtendimentoBlazor.Abstractions.Services;
using AtendimentoBlazor.Entities;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AtendimentoBlazor.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly ILogger<AuthService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string authTokenStorageKey;

        public AuthService(HttpClient client, IConfiguration config, AuthenticationStateProvider authStateProvider,
             ILocalStorageService localStorage, ILogger<AuthService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _config = config;
            _logger = logger;
            authTokenStorageKey = _config["authTokenStorageKey"]!;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<AuthenticatedUserModel?> Login(AuthModel userForAuthentication)
        {
            string jsonContent = JsonSerializer.Serialize(userForAuthentication);

            using var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            string loginEndpoint = _config["APIUrl"] + _config["Login"];
            var authResult = await _client.PostAsync(loginEndpoint, data);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro durante o login {authContent}", authContent);
                return null;
            }

            AuthenticatedUserModel? authenticatedUser = null;

            try
            {
                authenticatedUser = JsonSerializer.Deserialize<AuthenticatedUserModel>
                (
                    authContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (authenticatedUser is null)
                {
                    return null;
                }

                await SaveUserData(authenticatedUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao deserializar o login do usuário", ex);
            }

            return authenticatedUser;
        }

        public string? GetUserToken()
        {
            HttpContext? httpContext = _httpContextAccessor.HttpContext;

            if (httpContext is not null)
            {
                ClaimsPrincipal user = httpContext.User;

                if (user.Identity is not null && user.Identity.IsAuthenticated)
                {
                    return user.FindFirst("AccessToken")?.Value;
                }
            }

            return null;
        }

        public async Task LogoutAsync()
        {
            HttpContext? httpContext = _httpContextAccessor.HttpContext;

            if (httpContext is not null)
            {
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

        private async Task SaveUserData(AuthenticatedUserModel authenticatedUser)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, authenticatedUser.Username),
                new("AccessToken", authenticatedUser.Access_Token)
            };

            ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            AuthenticationProperties authProperties = new()
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
            };

            HttpContext? httpContext = _httpContextAccessor.HttpContext;

            if (httpContext is not null)
            {
                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal, authProperties);
            }
        }
    }
}
