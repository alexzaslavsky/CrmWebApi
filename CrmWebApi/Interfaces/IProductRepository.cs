using CrmWebApi.Domain.Core;
using System.Collections.Generic;

namespace CrmWebApi.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        string GetTheMostFrequentCategoryName();
    }
}
