using AtendimentoDomain.Entities;

namespace AtendimentoApi.Dtos.Response
{
    public sealed class UserResponse
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<AtendimentoResponse>? Atendimentos { get; set; }
    }
}
