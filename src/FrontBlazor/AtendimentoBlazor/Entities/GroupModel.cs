namespace AtendimentoBlazor.Entities
{
    public class GroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserModel>? Users { get; set; }
    }
}
