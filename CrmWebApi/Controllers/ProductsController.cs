using CrmWebApi.Domain.Core;
using CrmWebApi.Interfaces;
using CrmWebApi.Services;
using CrmWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrmWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            return _productService.GetAll();
        }

        [HttpGet]
        [Route("/MostFrequentCategory")]
        public string GetTheMostFrequentCategoryName()
        {
            return _productService.GetTheMostFrequentCategoryName();
        }
    }
}
