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


    }
}
