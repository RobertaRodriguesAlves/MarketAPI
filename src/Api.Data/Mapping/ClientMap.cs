using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(client => client.Id);
            builder.HasIndex(client => client.Document).IsUnique();
            builder.Property(client => client.Password).IsRequired().HasMaxLength(15);
            builder.Property(client => client.Name).IsRequired().HasMaxLength(80);
            builder.Property(client => client.Email).IsRequired().HasMaxLength(60);
            builder.Property(client => client.Document).IsRequired().HasMaxLength(18);
        }
    }
}