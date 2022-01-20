using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext;
using CrmWebApi.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace CrmWebApi.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductCategoryRepository(DatabaseContext databaseContext)
        {
            GuardClauses.IsNotNull(databaseContext, nameof(databaseContext));
            this._databaseContext = databaseContext;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _databaseContext.ProductCategories.ToList();
        }

        public int CreateProductCategory(ProductCategory productCategory)
        {
            _databaseContext.Add(productCategory);
            return _databaseContext.SaveChanges();
        }
    }
}
