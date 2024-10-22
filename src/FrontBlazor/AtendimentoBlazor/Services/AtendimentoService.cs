using AtendimentoBlazor.Abstractions.Services;
using AtendimentoBlazor.Entities;
using System.Text;
using System.Text.Json;

namespace AtendimentoBlazor.Services
{
    public sealed class AtendimentoService : IAtendimentoService
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

        public async Task<AtendimentoModel?> GetById(Guid id)
        {
            string endpoint = _config["APIUrl"] + _config["GetAtendimentoById"] + $"/{id}";
            var authResult = await _client.GetAsync(endpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro durante o carregamento do atendimento por id: {authContent}",
                    authContent);

                return null;
            }

            AtendimentoModel? atendimento = JsonSerializer.Deserialize<AtendimentoModel>(authContent);

            return atendimento;
        }

        public async Task<List<AtendimentoModel>?> GetAtendimentosByUserId(Guid userId)
        {
            string endpoint = _config["APIUrl"] + _config["GetAtendimentoByUserId"] + $"/{userId}";
            var authResult = await _client.GetAsync(endpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro durante o carregamento do atendimento por user id: {authContent}",
                    authContent);

                return null;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<AtendimentoModel>? atendimentos = JsonSerializer.Deserialize<List<AtendimentoModel>?>(authContent, options);

            return atendimentos;
        }

        public async Task<string?> Add(AtendimentoModel atendimento)
        {
            string jsonContent = JsonSerializer.Serialize(atendimento);

            using var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");


            string addEndpoint = _config["APIUrl"] + _config["AddAtendimento"];
            HttpResponseMessage authResult = await _client.PostAsync(addEndpoint, data);
            string authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu para criar o atendimento: {authContent}", authContent);

                return await authResult.Content.ReadAsStringAsync(); ;
            }

            return null;
        }

        public async Task<string?> Delete(Guid id)
        {
            string endpoint = _config["APIUrl"] + _config["DeleteAtendimento"] + $"/{id}";
            var authResult = await _client.DeleteAsync(endpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro para deletar o atendimento: {authContent}",
                    authContent);

                return await authResult.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
