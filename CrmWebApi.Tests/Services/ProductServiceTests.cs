using AutoMapper;
using CrmWebApi.Automappings;
using CrmWebApi.Domain.Core;
using CrmWebApi.Interfaces;
using CrmWebApi.Services;
using CrmWebApi.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmWebApi.Tests.Services
{
    internal class ProductServiceTests
    {
        IProductService sut;

        IProductRepository productRepository;

        IMapper mapper;

        [SetUp]
        public void Setup()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetAll()).Returns(GetAllProducts());
            productRepository = productRepositoryMock.Object;

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new ProductMapperProfile()));
            mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public void GetAll_Returns_Eight_Products()
        {
            //Arrange
            sut = new ProductService(productRepository, mapper);

            //Act
            var result = sut.GetAll().Count();

            //Assert
            Assert.AreEqual(8, result);
        }

        [Test]
        public void GetAll_Returns_IEnumerable_Of_ProductViewModel()
        {
            //Arrange
            sut = new ProductService(productRepository, mapper);

            //Act
            var result = sut.GetAll() is IEnumerable<ProductViewModel>;

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Service_Throws_ArgumentNullException_When_Repo_Is_Null()
        {
            Assert.That(() =>
            {
                sut = new ProductService(null, mapper);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Service_Throws_ArgumentNullException_When_Mapper_Is_Null()
        {
            Assert.That(() =>
            {
                sut = new ProductService(productRepository, null);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        private IEnumerable<Product> GetAllProducts()
        {
            var smartphone = new ProductCategory() { Id = 1, Name = "Smartphone" };
            var laptop = new ProductCategory() { Id = 2, Name = "Laptop" };
            var tv = new ProductCategory() { Id = 3, Name = "TV" };

            return new Product[]
                {
                    new Product { Id = 2, Name = "IPhone 13 Pro", Price = 39000, CategoryId = 1, Category = smartphone },
                    new Product { Id = 3, Name = "Samsung Galaxy A12", Price = 5500, CategoryId = 1, Category = smartphone },
                    new Product { Id = 1, Name = "Xiaomi Redmi Note 10", Price = 7000, CategoryId = 1, Category = smartphone },
                    new Product { Id = 4, Name = "Huawei Nova 8i", Price = 10000, CategoryId = 1, Category = smartphone },
                    new Product { Id = 5, Name = "Oppo A74", Price = 8900, CategoryId = 1, Category = smartphone },
                    new Product { Id = 6, Name = "HP EliteBook", Price = 45000, CategoryId = 2, Category = laptop },
                    new Product { Id = 7, Name = "ASUS ZenBook", Price = 35000, CategoryId = 2, Category = laptop },
                    new Product { Id = 8, Name = "Samsung QE55Q60AAUXUA", Price = 36000, CategoryId = 3, Category = tv }
                };
        }
    }
}
