using AtendimentoBlazor.Abstractions.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace AtendimentoBlazor.Services.Session
{
    public class SessionService : ISessionService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public SessionService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Guid> GetLoggedInUserId()
        {
            AuthenticationState authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            ClaimsPrincipal user = authenticationState.User;
            string? idUsuario = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (idUsuario is null)
            {
                return Guid.Empty;
            }

            return new Guid(idUsuario);
        }
    }
}
