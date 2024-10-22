using AtendimentoDomain.Primitives;

namespace AtendimentoDomain.Entities
{
    public sealed class User : Entity
    {
        public Guid GroupId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Group? Group { get; set; }
        public List<Atendimento>? Atendimentos { get; set; }
    }
}
