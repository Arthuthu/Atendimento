namespace AtendimentoBlazor.Entities
{
    public class GroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid? UserOwnerId { get; set; }
        public List<Guid>? UsersId { get; set; }
    }
}
