using CrmWebApi.Domain.Core;
using CrmWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        [HttpGet]
        [Route("/MostFrequentCategory")]
        public string GetTheMostFrequentCategoryName()
        {
            return _productRepository.GetTheMostFrequentCategoryName();
        }
    }
}
