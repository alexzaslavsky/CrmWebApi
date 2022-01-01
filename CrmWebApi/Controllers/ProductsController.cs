using CrmWebApi.Domain.Core;
using CrmWebApi.Interfaces;
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
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            var products = _productRepository.GetAll();
            return products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                IsAvailable = p.IsAvailable,
                CategoryId = p.CategoryId,
                Description = p.Description
            }).ToList();
        }

        [HttpGet]
        [Route("/MostFrequentCategory")]
        public string GetTheMostFrequentCategoryName()
        {
            return _productRepository.GetTheMostFrequentCategoryName();
        }
    }
}
