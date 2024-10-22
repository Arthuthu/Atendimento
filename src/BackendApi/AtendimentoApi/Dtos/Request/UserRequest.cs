namespace AtendimentoApi.Dtos.Request
{
    public sealed class UserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<AtendimentoRequest>? Atendimentos { get; set; }
        public GroupRequest? Group { get; set; }
    }
}
