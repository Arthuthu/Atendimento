using AtendimentoDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoInfra.Mapping
{
    public class GroupMapping : BaseMapping<Group>
    {
        public GroupMapping() : base("Group")
        {
        }

        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasMany(x => x.Users)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.Id);
        }
    }
}
