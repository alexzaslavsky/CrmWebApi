using AutoMapper;
using CrmWebApi.Domain.Core;
using CrmWebApi.Helpers;
using CrmWebApi.Repositories;
using CrmWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CrmWebApi.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            GuardClauses.IsNotNull(productCategoryRepository, nameof(productCategoryRepository));
            GuardClauses.IsNotNull(mapper, nameof(mapper));
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductCategoryViewModel> GetAll()
        {
            try
            {
                var categories = _productCategoryRepository.GetAll();
                return _mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return Enumerable.Empty<ProductCategoryViewModel>();
            }
        }

        public int CreateProductCategory(CreationProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);
                return _productCategoryRepository.CreateProductCategory(productCategory);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
