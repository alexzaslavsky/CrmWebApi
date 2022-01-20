using CrmWebApi.Services;
using CrmWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IEnumerable<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryService.GetAll();
        }

        [HttpPost("CreateProductCategory")]
        public ActionResult CreateProductCategory(CreationProductCategoryViewModel category)
        {
            if (_productCategoryService.CreateProductCategory(category) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
