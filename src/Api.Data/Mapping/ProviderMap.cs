using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ProviderMap : IEntityTypeConfiguration<ProviderEntity>
    {
        public void Configure(EntityTypeBuilder<ProviderEntity> builder)
        {
            builder.ToTable("Providers");
            builder.HasKey(prov => prov.Id);
            builder.HasIndex(prov => prov.Cnpj).IsUnique();
            builder.Property(prov => prov.Cnpj).IsRequired().HasMaxLength(18);
            builder.Property(prov => prov.Name).IsRequired().HasMaxLength(80);
        }
    }
}