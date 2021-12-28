using CrmWebApi.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace CrmWebApi.Domain.DatabaseContext.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            ProductCategorySeed(modelBuilder);
            ProductSeed(modelBuilder);
        }

        private static void ProductCategorySeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory[]
                {
                    new ProductCategory { Id = 1, Name = "Smartphone" },
                    new ProductCategory { Id = 2, Name = "Laptop" },
                    new ProductCategory { Id = 3, Name = "TV"}
                });
        }

        private static void ProductSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product { Id = 1, Name = "Xiaomi Redmi Note 10", Price  = 7000, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 2, Name = "IPhone 13 Pro", Price = 39000, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 3, Name = "Samsung Galaxy A12", Price = 5500, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 4, Name = "Huawei Nova 8i", Price = 10000, CategoryId = 1, IsAvailable = true },
                    new Product { Id = 5, Name = "Oppo A74", Price = 8900, CategoryId = 1, IsAvailable = true }
                });
        }
    }
}