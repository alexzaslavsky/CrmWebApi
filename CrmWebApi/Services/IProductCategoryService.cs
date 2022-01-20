using CrmWebApi.ViewModels;
using System.Collections.Generic;

namespace CrmWebApi.Services
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategoryViewModel> GetAll();
        int CreateProductCategory(CreationProductCategoryViewModel category);
    }
}
