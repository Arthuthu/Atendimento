using AtendimentoDomain.Primitives;

namespace AtendimentoDomain.Entities
{
    public sealed class User : Entity
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Atendimento> Atendimentos { get; set; } = [];
    }
}
