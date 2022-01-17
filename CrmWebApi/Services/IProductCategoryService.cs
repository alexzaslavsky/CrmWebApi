using CrmWebApi.ViewModels;
using System.Collections.Generic;

namespace CrmWebApi.Services
{
    public interface IProductCategoryService
    {
        Dictionary<string, int> GetAll();
        int CreateProductCategory(ProductCategoryViewModel category);
    }
}
