using CrmWebApi.Controllers;
using CrmWebApi.Services;
using CrmWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace CrmWebApi.Tests.Controllers
{
    [TestFixture]
    public class ProductCategoriesControllerTests
    {
        IProductCategoryService _productCategoryService;
        ProductCategoriesController _sut;

        [SetUp]
        public void Setup()
        {
            _productCategoryService = Substitute.For<IProductCategoryService>();
            _productCategoryService.GetAll().Returns(Enumerable.Empty<ProductCategoryViewModel>());

            _sut = new ProductCategoriesController(_productCategoryService);
        }

        [Test]
        public void GetAll_Calls_GetAll_Of_Service()
        {
            _sut.GetAll();

            _productCategoryService.Received(1).GetAll();
        }

        [Test]
        public void GetAll_Returns_Collection_Of_ProductCategoryViewModel()
        {
            var result = _sut.GetAll();

            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(ProductCategoryViewModel));
        }

        [Test]
        public void CreateProductCategory_Calls_Service_CreateProductCategory()
        {
            var creationCategory = new CreationProductCategoryViewModel();

            _sut.CreateProductCategory(creationCategory);

            _productCategoryService.Received(1).CreateProductCategory(creationCategory);
        }

        [Test]
        public void CreateProductCategory_Returns_OkResult_When_Category_IsNotNull()
        {
            var category = new CreationProductCategoryViewModel();
            _productCategoryService.CreateProductCategory(category).Returns(1);

            var result = _sut.CreateProductCategory(category);

            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void CreateProductCategory_Returns_BadRequestResult_When_Category_IsNull()
        {
            _productCategoryService.CreateProductCategory(null).Returns(0);

            var result = _sut.CreateProductCategory(null);

            Assert.IsInstanceOf<BadRequestResult>(result);
        }
    }
}
