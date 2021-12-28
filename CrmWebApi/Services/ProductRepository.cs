using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext;
using CrmWebApi.DTO;
using CrmWebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CrmWebApi.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public IEnumerable<ProductDto> GetAll()
        {
            return _databaseContext.Products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                Price = product.Price,
                CategoryId = product.CategoryId
            });
        }

        public string GetTheMostFrequentCategoryName()
        {
            return _databaseContext.ProductCategories
                .OrderByDescending(c => c.Products.Count).FirstOrDefault()?.Name;
        }
    }
}
