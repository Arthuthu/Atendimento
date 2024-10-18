using AtendimentoDomain.Entities;

namespace AtendimentoApi.Dtos.Request
{
    public sealed class AtendimentoRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Versao { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public User? User { get; set; }
    }
}
