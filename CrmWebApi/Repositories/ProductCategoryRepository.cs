using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext;
using CrmWebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CrmWebApi.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductCategoryRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return databaseContext.ProductCategories.ToList();
        }

        public int CreateProductCategory(ProductCategory productCategory)
        {
            databaseContext.Add(productCategory);
            return databaseContext.SaveChanges();
        }
    }
}
