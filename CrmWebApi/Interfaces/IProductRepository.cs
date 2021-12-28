using CrmWebApi.DTO;
using System.Collections.Generic;

namespace CrmWebApi.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAll();
        string GetTheMostFrequentCategoryName();
    }
}
