using AutoMapper;
using CrmWebApi.Automappings;
using CrmWebApi.Domain.Core;
using CrmWebApi.Repositories;
using CrmWebApi.Services;
using CrmWebApi.ViewModels;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace CrmWebApi.Tests.Services
{
    [TestFixture]
    public class ProductCategoryServiceTests
    {
        IProductCategoryRepository _repository;
        IMapper _mapper;
        IProductCategoryService _sut;

        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<IProductCategoryRepository>();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new ProductCategoryMapperProfile()));
            _mapper = mapperConfig.CreateMapper();

            _sut = new ProductCategoryService(_repository, _mapper);
        }

        [Test]
        public void GetAll_Calls_Repo_GetAll()
        {
            _repository.GetAll().Returns(Enumerable.Empty<ProductCategory>());

            _sut.GetAll();

            _repository.Received(1).GetAll();
        }

        [Test]
        public void CreateProductCategory_Calls_Repo_CreateProductCategory()
        {
            var creationCategory = new CreationProductCategoryViewModel();
            var productCategory = _mapper.Map<ProductCategory>(creationCategory);
            _repository.CreateProductCategory(productCategory).Returns(1);

            _sut.CreateProductCategory(creationCategory);

            _repository.Received(1).CreateProductCategory(Arg.Any<ProductCategory>());
        }

        [Test]
        public void If_Repo_CreateProductCategory_Receives_Null_Then_Service_Returns_Zero()
        {
            var creationCategory = new CreationProductCategoryViewModel();
            _repository.CreateProductCategory(null).Returns(0);

            var result = _sut.CreateProductCategory(creationCategory);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
