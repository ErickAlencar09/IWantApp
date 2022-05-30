using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .Property(p => p.Name).IsRequired();
            builder.Entity<Product>()
                .Property(p => p.Description).HasMaxLength(200);

            builder.Entity<Category>()
                .Property(p => p.Name).HasMaxLength(200);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>()
                .HaveMaxLength(100);
        }
    }
}
