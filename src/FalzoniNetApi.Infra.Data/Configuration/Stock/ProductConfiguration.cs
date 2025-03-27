using FalzoniNetApi.Domain.Entities.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoniNetApi.Infra.Data.Configuration.Stock
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(512);

            builder.Property(p => p.Price).IsRequired().HasPrecision(18, 2);

            builder.Property(p => p.Discount).HasPrecision(18, 2);

            builder.Property(p => p.Created).IsRequired();

            builder.Property(p => p.Modified);
        }
    }
}
