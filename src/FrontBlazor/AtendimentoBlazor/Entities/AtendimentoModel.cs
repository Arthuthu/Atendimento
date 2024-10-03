namespace AtendimentoBlazor.Entities
{
    public sealed class AtendimentoModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Versao { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public UserModel? User { get; set; }
    }
}
