using AtendimentoBlazor.Entities;
using System.Text.Json;
using System.Text;
using AtendimentoBlazor.Abstractions.Services;
using System.Collections.Generic;

namespace AtendimentoBlazor.Services
{
    public sealed class GroupService : IGroupService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ILogger<GroupService> _logger;

        public GroupService(HttpClient client, IConfiguration config, ILogger<GroupService> logger)
        {
            _client = client;
            _config = config;
            _logger = logger;
        }

        public async Task<GroupModel?> GetById(Guid id)
        {
            string endpoint = _config["APIUrl"] + _config["GetGroupById"] + $"/{id}";
            var authResult = await _client.GetAsync(endpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro durante o carregamento do group por id: {authContent}",
                    authContent);

                return null;
            }

            GroupModel? result = JsonSerializer.Deserialize<GroupModel>(authContent);

            return result;
        }
        public async Task<List<GroupModel>?> GetGroupsByUserId(Guid id)
        {
            string endpoint = _config["APIUrl"] + _config["GetGroupsByUserId"] + $"/{id}";
            var authResult = await _client.GetAsync(endpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro durante o carregamento dos group por user id: {authContent}",
                    authContent);

                return null;
            }

            List<GroupModel>? result = JsonSerializer.Deserialize<List<GroupModel>?>(authContent);

            return result;
        }

        public async Task<string?> Add(GroupModel group)
        {
            string jsonContent = JsonSerializer.Serialize(group);

            using var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            string addEndpoint = _config["APIUrl"] + _config["AddGroup"];
            HttpResponseMessage authResult = await _client.PostAsync(addEndpoint, data);
            string authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu para criar o group: {authContent}", authContent);

                return await authResult.Content.ReadAsStringAsync(); ;
            }

            return null;
        }

        public async Task<string?> Delete(Guid id)
        {
            string endpoint = _config["APIUrl"] + _config["DeleteGroup"] + $"/{id}";
            var authResult = await _client.DeleteAsync(endpoint);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode is false)
            {
                _logger.LogError("Ocorreu um erro para deletar o group: {authContent}",
                    authContent);

                return await authResult.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
