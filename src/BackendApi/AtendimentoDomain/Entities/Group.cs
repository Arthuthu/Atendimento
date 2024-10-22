using AtendimentoDomain.Primitives;

namespace AtendimentoDomain.Entities
{
    public sealed class Group : Entity
    {
        public string Name { get; set; } = string.Empty;

        public List<User>? Users { get; set; }
    }
}
