using AtendimentoBlazor.Abstractions.Services;
using AtendimentoBlazor.Entities;
using Newtonsoft.Json;
using System.Text;

namespace AtendimentoBlazor.Services
{
    public sealed class UserService : IUserService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ILogger<UserService> _logger;
        public UserService(HttpClient client, IConfiguration config, ILogger<UserService> logger)
        {
            _client = client;
            _config = config;
            _logger = logger;
        }
        public async Task<User?> GetById(Guid id)
        {
            string buscarPorIdEndpoint = _config["APIUrl"] + _config["GetUserById"] + $"/{id}";
            var authResult = await _client.GetAsync(buscarPorIdEndpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro durante o carregamento do usuario por id: {authContent}",
                    authContent);

                return null;
            }

            var user = JsonConvert.DeserializeObject<User>(authContent);

            return user;
        }

        public async Task<string?> Add(User user)
        {
            string jsonContent = JsonConvert.SerializeObject(user);

            using var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            string addEndpoint = _config["APIUrl"] + _config["AddUser"];
            HttpResponseMessage authResult = await _client.PostAsync(addEndpoint, data);
            string authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu para criar o usuario: {authContent}", authContent);

                return await authResult.Content.ReadAsStringAsync();
            }

            return null;
        }

        public async Task<string?> Delete(Guid id)
        {
            string deleteEndpoint = _config["APIUrl"] + _config["DeletarUsuario"] + $"/{id}";
            var authResult = await _client.DeleteAsync(deleteEndpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro para deletar o usuario: {authContent}",
                    authContent);

                return await authResult.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
