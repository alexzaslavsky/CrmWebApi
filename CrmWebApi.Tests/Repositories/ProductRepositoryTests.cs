using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext;
using CrmWebApi.Interfaces;
using CrmWebApi.Repositories;
using EntityFrameworkCore.Testing.NSubstitute;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace CrmWebApi.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        DatabaseContext _databaseContext;

        IProductRepository _sut;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _databaseContext = Create.MockedDbContextFor<DatabaseContext>(options);

            FillDbSets();

            _sut = new ProductRepository(_databaseContext);
        }

        [Test]
        public void GetAll_Returns_Count_Eight_When_Eight_Products_Exist_In_Database()
        {
            var result = _sut.GetAll().Count();

            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void GetAll_Returns_Eight_Products_When_Eight_Products_Exist_In_Database()
        {
            var names = new string[]
            {
                "IPhone 13 Pro",
                "Samsung Galaxy A12",
                "Xiaomi Redmi Note 10",
                "Huawei Nova 8i",
                "Oppo A74",
                "HP EliteBook",
                "ASUS ZenBook",
                "Samsung QE55Q60AAUXUA"
            };

            var products = _sut.GetAll();

            bool containsAll = products.All(x => names.Contains(x.Name));

            Assert.That(containsAll, Is.True);
        }

        [Test]
        public void GetTheMostFrequentCategoryName_Returns_Smartphone_Category()
        {
            var result = _sut.GetTheMostFrequentCategoryName();

            Assert.That(result, Is.EqualTo("Smartphone"));
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