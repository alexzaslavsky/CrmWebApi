﻿using AutoMapper;
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
        IProductRepository _productRepository;
        IMapper _mapper;
        IProductService _sut;

        [SetUp]
        public void Setup()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _productRepository.GetAll().Returns(Enumerable.Empty<Product>());

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new ProductMapperProfile()));
            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public void GetAll_Calls_Repo_GetAll()
        {
            //Arrange
            _sut = new ProductService(_productRepository, _mapper);

            //Act
            _sut.GetAll();

            //Assert
            _productRepository.Received(1).GetAll();
        }

        [Test]
        public void GetAll_Returns_IEnumerable_Of_ProductViewModel()
        {
            //Arrange
            _sut = new ProductService(_productRepository, _mapper);

            //Act
            var result = _sut.GetAll();

            //Assert
            Assert.That(result is IEnumerable<ProductViewModel>, Is.True);
        }

        [Test]
        public void Ctor_Throws_ArgumentNullException_When_Repo_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                _sut = new ProductService(null, _mapper);
            });

            Assert.That(ex.ParamName, Is.EqualTo("productRepository"));
        }

        [Test]
        public void Ctor_Throws_ArgumentNullException_When_Mapper_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                _sut = new ProductService(_productRepository, null);
            });

            Assert.That(ex.ParamName, Is.EqualTo("mapper"));
        }
    }
}
