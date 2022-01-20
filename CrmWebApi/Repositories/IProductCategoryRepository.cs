using CrmWebApi.Domain.Core;
using System.Collections.Generic;

namespace CrmWebApi.Repositories
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetAll();
        int CreateProductCategory(ProductCategory productCategory);
    }
}
