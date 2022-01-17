using AutoMapper;
using CrmWebApi.Domain.Core;
using CrmWebApi.ViewModels;

namespace CrmWebApi.Automappings
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
