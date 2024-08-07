using AtendimentoDomain.Primitives;

namespace AtendimentoDomain.Entities
{
    public sealed class Atendimento : Entity
    {
        public Guid UserId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Versao { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public User User { get; set; } = new();
    }
}
