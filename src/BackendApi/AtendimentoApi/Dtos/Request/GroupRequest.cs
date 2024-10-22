namespace AtendimentoApi.Dtos.Request
{
    public sealed class GroupRequest
    {
        public string Name { get; set; } = string.Empty;
        public List<UserRequest>? Users { get; set; }
    }
}
