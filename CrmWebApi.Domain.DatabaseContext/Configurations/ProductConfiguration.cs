using CrmWebApi.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrmWebApi.Domain.DatabaseContext.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ConfigureProperties(builder);
            Seed(builder);
        }

        protected virtual void ConfigureProperties(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(product => product.Description)
               .HasMaxLength(500);
        }

        protected virtual void Seed(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product[]
                {
                    new Product { Id = 1, Name = "Xiaomi Redmi Note 10", Price  = 7000, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 2, Name = "IPhone 13 Pro", Price = 39000, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 3, Name = "Samsung Galaxy A12", Price = 5500, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 4, Name = "Huawei Nova 8i", Price = 10000, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 5, Name = "Oppo A74", Price = 8900, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 6, Name = "HP EliteBook", Price = 45000, CategoryId = 2, IsAvailable = true },
                    new Product { Id = 7, Name = "ASUS ZenBook", Price = 35000, CategoryId = 2, IsAvailable = true },
                    new Product { Id = 8, Name = "Samsung QE55Q60AAUXUA", Price = 36000, CategoryId = 3, IsAvailable = true }
                });
        }
    }
}
