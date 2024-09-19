using AtendimentoBlazor.Entities;
using Newtonsoft.Json;

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

        public async Task<Atendimento?> GetById(Guid id)
        {
            string buscarPorIdEndpoint = _config["APIUrl"] + _config["GetAtendimentoById"] + $"/{id}";
            var authResult = await _client.GetAsync(buscarPorIdEndpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro durante o carregamento do atendimento por id: {authContent}",
                    authContent);

                return null;
            }

            Atendimento? atendimento = JsonConvert.DeserializeObject<Atendimento>(authContent);

            return atendimento;
        }

        public async Task<string?> Add(Atendimento atendimento)
        {
            using FormUrlEncodedContent data = new
            ([
                new KeyValuePair<string, string>("Codigo", atendimento.Codigo),
                new KeyValuePair<string, string>("Versao", atendimento.Versao),
                new KeyValuePair<string, string>("Descricao", atendimento.Descricao)
            ]);

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
            string deleteEndpoint = _config["APIUrl"] + _config["DeletarAtendimento"] + $"/{id}";
            var authResult = await _client.DeleteAsync(deleteEndpoint);
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
