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
        private readonly IProductCategoryService productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        [HttpGet]
        public Dictionary<string, int> GetAll()
        {
            return productCategoryService.GetAll();
        }

        [HttpPost("CreateProductCategory")]
        public ActionResult<ProductCategoryViewModel> CreateProductCategory(ProductCategoryViewModel category)
        {
            if (productCategoryService.CreateProductCategory(category) == 1)
            {
                return Ok(category);
            }
            return BadRequest();
            
        }
    }
}
