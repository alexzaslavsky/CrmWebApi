using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext;
using CrmWebApi.Repositories;
using EntityFrameworkCore.Testing.NSubstitute;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace CrmWebApi.Tests.Repositories
{
    [TestFixture]
    public class ProductCategoryRepositoryTests
    {
        DatabaseContext _databaseContext;
        IProductCategoryRepository _sut;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _databaseContext = Create.MockedDbContextFor<DatabaseContext>(options);

            FillDbSets();

            _sut = new ProductCategoryRepository(_databaseContext);
        }

        [Test]
        public void CreateProductCategory_Returns_One_When_Category_IsNotNull()
        {
            _sut = new ProductCategoryRepository(_databaseContext);

            var result = _sut.CreateProductCategory(new ProductCategory());

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void CreateProductCategory_Throws_ArgumentNullException_When_Category_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                _sut = new ProductCategoryRepository(_databaseContext);

                _sut.CreateProductCategory(null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("entity"));
        }

        [Test]
        public void Ctor_Throws_ArgumentNullException_When_Context_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                _sut = new ProductCategoryRepository(null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("databaseContext"));
        }

        private void FillDbSets()
        {
            var smartphone = new ProductCategory() { Id = 1, Name = "Smartphone" };
            var laptop = new ProductCategory() { Id = 2, Name = "Laptop" };
            var tv = new ProductCategory() { Id = 3, Name = "TV" };

            _databaseContext
                .Set<ProductCategory>()
                .AddRange(new ProductCategory[] { smartphone, laptop, tv });

            _databaseContext
                .Set<Product>()
                .AddRange(new Product[]
                {
                    new Product { Id = 2, Name = "IPhone 13 Pro", Price = 39000, CategoryId = 1, Category = smartphone },
                    new Product { Id = 3, Name = "Samsung Galaxy A12", Price = 5500, CategoryId = 1, Category = smartphone },
                    new Product { Id = 1, Name = "Xiaomi Redmi Note 10", Price = 7000, CategoryId = 1, Category = smartphone },
                    new Product { Id = 4, Name = "Huawei Nova 8i", Price = 10000, CategoryId = 1, Category = smartphone },
                    new Product { Id = 5, Name = "Oppo A74", Price = 8900, CategoryId = 1, Category = smartphone },
                    new Product { Id = 6, Name = "HP EliteBook", Price = 45000, CategoryId = 2, Category = laptop },
                    new Product { Id = 7, Name = "ASUS ZenBook", Price = 35000, CategoryId = 2, Category = laptop },
                    new Product { Id = 8, Name = "Samsung QE55Q60AAUXUA", Price = 36000, CategoryId = 3, Category = tv }
                });

            _databaseContext.SaveChanges();
        }
    }
}
