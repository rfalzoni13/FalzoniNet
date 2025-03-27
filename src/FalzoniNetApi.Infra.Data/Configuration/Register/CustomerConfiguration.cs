using FalzoniNetApi.Domain.Entities.Register;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalzoniNetApi.Infra.Data.Configuration.Register
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(128);

            builder.Property(c => c.Document).IsRequired().HasMaxLength(20);

            builder.Property(c => c.Created).IsRequired();

            builder.Property(c => c.Modified);
        }
    }
}
