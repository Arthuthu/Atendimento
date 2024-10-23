namespace AtendimentoApi.Dtos.Response
{
    public sealed class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<AtendimentoResponse>? Atendimentos { get; set; }
        public List<GroupResponse>? Groups { get; set; }
    }
}
