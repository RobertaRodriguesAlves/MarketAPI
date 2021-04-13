using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(product => product.Id);
            builder.HasIndex(product => product.Name).IsUnique();
            builder.Property(product => product.Price).IsRequired();
            builder.Property(product => product.Amount).IsRequired();
            builder.Property(product => product.Category).IsRequired();
            builder.Property(product => product.Promotion).IsRequired();
            builder.Property(product => product.Name).IsRequired().HasMaxLength(80);
        }
    }
}