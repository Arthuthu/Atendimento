namespace AtendimentoApi.Dtos.Request
{
    public sealed class GroupRequest
    {
        public string Name { get; set; } = string.Empty;
        public Guid? UserOwnerId { get; set; }
        public List<Guid>? UsersId { get; set; }
    }
}
