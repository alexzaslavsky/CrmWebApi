using AutoMapper;
using CrmWebApi.Automappings;
using CrmWebApi.Domain.Core;
using CrmWebApi.Interfaces;
using CrmWebApi.Services;
using CrmWebApi.ViewModels;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmWebApi.Tests.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        IProductRepository productRepository;
        IMapper mapper;
        IProductService sut;

        [SetUp]
        public void Setup()
        {
            productRepository = Substitute.For<IProductRepository>();
            productRepository.GetAll().Returns(Enumerable.Empty<Product>());

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new ProductMapperProfile()));
            mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public void GetAll_Calls_Repo_GetAll()
        {
            //Arrange
            sut = new ProductService(productRepository, mapper);

            //Act
            sut.GetAll();

            //Assert
            productRepository.Received(1).GetAll();
        }

        [Test]
        public void GetAll_Returns_IEnumerable_Of_ProductViewModel()
        {
            //Arrange
            sut = new ProductService(productRepository, mapper);

            //Act
            var result = sut.GetAll();

            //Assert
            Assert.That(result is IEnumerable<ProductViewModel>, Is.True);
        }

        [Test]
        public void Ctor_Throws_ArgumentNullException_When_Repo_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                sut = new ProductService(null, mapper);
            });

            Assert.That(ex.ParamName, Is.EqualTo("productRepository"));
        }

        [Test]
        public void Ctor_Throws_ArgumentNullException_When_Mapper_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                sut = new ProductService(productRepository, null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("mapper"));
        }
    }
}
