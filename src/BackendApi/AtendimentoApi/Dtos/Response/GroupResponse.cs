using AtendimentoInfra.Repositories;

namespace AtendimentoApi.Dtos.Response
{
    public sealed class GroupResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<UserRepository>? Users { get; set; }
    }
}
