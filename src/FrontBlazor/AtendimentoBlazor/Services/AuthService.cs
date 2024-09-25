using AtendimentoBlazor.Abstractions.Services;
using AtendimentoBlazor.Entities;
using Newtonsoft.Json;
using System.Text;

namespace AtendimentoBlazor.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthService> _logger;
        public AuthService(HttpClient client, IConfiguration config, ILogger<AuthService> logger)
        {
            _client = client;
            _config = config;
            _logger = logger;
        }
        public async Task<string?> Login(Auth auth)
        {
            string jsonContent = JsonConvert.SerializeObject(auth);

            using var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            string addEndpoint = _config["APIUrl"] + _config["Login"];
            HttpResponseMessage authResult = await _client.PostAsync(addEndpoint, data);
            string authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro durante o carregamento do usuario por id: {authContent}",
                    authContent);

                return null;
            }

            return await authResult.Content.ReadAsStringAsync();
        }
    }
}
