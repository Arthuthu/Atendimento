using AtendimentoBlazor.Entities;

namespace AtendimentoBlazor.Services
{
    public sealed class AtendimentoService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ILogger<AtendimentoService> _logger;

        public AtendimentoService(HttpClient client, IConfiguration config, ILogger<AtendimentoService> logger)
        {
            _client = client;
            _config = config;
            _logger = logger;
        }

        public async Task<string?> Add(User user)
        {
            using FormUrlEncodedContent data = new(
            [
                new KeyValuePair<string, string>("Username", user.Username),
                new KeyValuePair<string, string>("Password", user.Password),
                new KeyValuePair<string, string>("Email", user.Email)
            ]);

            string addEndpoint = _config["apiUrl"] + _config["addUser"];
            HttpResponseMessage authResult = await _client.PostAsync(addEndpoint, data);
            string authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu para criar o usuario: {authContent}", authContent);

                return await authResult.Content.ReadAsStringAsync(); ;
            }

            return null;
        }
    }
}
