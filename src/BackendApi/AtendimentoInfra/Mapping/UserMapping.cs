using AtendimentoDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtendimentoInfra.Mapping
{
    public sealed class UserMapping : BaseMapping<User>
    {
        public UserMapping() : base("Users")
        {
        }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasMaxLength(40);
            builder.Property(x => x.Password).HasMaxLength(30);
            builder.Property(x => x.Email).HasMaxLength(30);
            builder.HasMany(x => x.Atendimentos)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.Username);
        }
    }
}
