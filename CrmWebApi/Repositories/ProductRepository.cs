using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext;
using CrmWebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CrmWebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _databaseContext.Products.ToList();
        }

        public string GetTheMostFrequentCategoryName()
        {
            return _databaseContext.Products
                .GroupBy(product => product.Category.Name)
                .Select(group => new {CategoryName = group.Key, Count = group.Count()})
                .OrderByDescending(item => item.Count)
                .FirstOrDefault()?.CategoryName;
        }
    }
}
