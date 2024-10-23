using AtendimentoDomain.Primitives;

namespace AtendimentoDomain.Entities
{
    public sealed class Group : Entity
    {
        public string Name { get; set; } = string.Empty;
        public Guid? UserOwnerId { get; set; }
        public List<Guid>? UsersId { get; set; }
    }
}
