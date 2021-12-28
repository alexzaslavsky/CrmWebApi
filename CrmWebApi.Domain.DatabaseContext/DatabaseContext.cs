using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CrmWebApi.Domain.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ProductConfiguration(modelBuilder);
            ProductCategoryConfiguration(modelBuilder);
            modelBuilder.Seed();
        }

        protected virtual void ProductConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(128);

            modelBuilder.Entity<Product>()
               .Property(product => product.Description)
               .HasMaxLength(500);
        }

        protected virtual void ProductCategoryConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
