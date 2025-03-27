using FalzoniNetApi.Domain.Entities.Register;
using FalzoniNetApi.Domain.Entities.Stock;
using FalzoniNetApi.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FalzoniNetApi.Infra.Data.Context
{
    public class FalzoniNetApiContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public FalzoniNetApiContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Customer>? Customer { get; set; }
        public DbSet<Product>? Product{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<>).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
