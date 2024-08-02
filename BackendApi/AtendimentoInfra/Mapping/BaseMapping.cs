using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtendimentoInfra.Mapping
{
    public class BaseMapping<T> : IEntityTypeConfiguration<T> where T : class
    {
        private readonly string _tableName;

        public BaseMapping(string tableName)
        {
            _tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(_tableName))
            {
                builder.ToTable(_tableName);
            }
        }
    }
}
