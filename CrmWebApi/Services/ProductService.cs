using AutoMapper;
using CrmWebApi.Helpers;
using CrmWebApi.Interfaces;
using CrmWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CrmWebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            GuardClauses.IsNotNull(productRepository, nameof(productRepository));
            GuardClauses.IsNotNull(mapper, nameof(mapper));
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            try
            {
                var products = _productRepository.GetAll();
                return _mapper.Map<IEnumerable<ProductViewModel>>(products);

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return Enumerable.Empty<ProductViewModel>();
            }
        }

        public string GetTheMostFrequentCategoryName()
        {
            try
            {
                return _productRepository.GetTheMostFrequentCategoryName();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
