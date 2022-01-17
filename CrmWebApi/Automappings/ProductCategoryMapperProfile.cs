using AutoMapper;
using CrmWebApi.Domain.Core;
using CrmWebApi.ViewModels;

namespace CrmWebApi.Automappings
{
    public class ProductCategoryMapperProfile : Profile
    {
        public ProductCategoryMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
        }
    }
}
