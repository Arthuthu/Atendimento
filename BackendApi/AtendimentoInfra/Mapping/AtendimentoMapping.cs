using AtendimentoDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtendimentoInfra.Mapping
{
    public class AtendimentoMapping : BaseMapping<Atendimento>
    {
        public AtendimentoMapping() : base("Atendimento")
        {
        }

        public override void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).HasMaxLength(10);
            builder.Property(x => x.Versao).HasMaxLength(50);
            builder.Property(x => x.Descricao).HasMaxLength(2000);
            builder.Property(x => x.UserId);

            builder.HasIndex(x => x.Codigo);
        }
    }
}
