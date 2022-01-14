using AutoMapper;
using CrmWebApi.Interfaces;
using CrmWebApi.ViewModels;
using System;
using System.Collections.Generic;

namespace CrmWebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public string GetTheMostFrequentCategoryName()
        {
            return _productRepository.GetTheMostFrequentCategoryName();
        }
    }
}
