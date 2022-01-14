using CrmWebApi.ViewModels;
using System.Collections.Generic;

namespace CrmWebApi.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAll();

        string GetTheMostFrequentCategoryName();
    }
}
