using CrmWebApi.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrmWebApi.Domain.DatabaseContext.Configurations
{
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            ConfigureProperties(builder);
            Seed(builder);
        }

        protected virtual void ConfigureProperties(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(128);
        }

        protected virtual void Seed(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(
                new ProductCategory[]
                {
                    new ProductCategory { Id = 1, Name = "Smartphone" },
                    new ProductCategory { Id = 2, Name = "Laptop" },
                    new ProductCategory { Id = 3, Name = "TV"}
                });
        }
    }
}
