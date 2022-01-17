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
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IMapper mapper;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            GuardClauses.IsNotNull(productCategoryRepository, nameof(productCategoryRepository));
            GuardClauses.IsNotNull(mapper, nameof(mapper));
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
        }

        public Dictionary<string, int> GetAll()
        {
            try
            {
                return productCategoryRepository
                    .GetAll()
                    .Select(c => new { 
                        CategoryName =  c.Name,
                        TotalProducts = c.Products.Count
                    })
                    .ToDictionary(item => item.CategoryName, item => item.TotalProducts);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return new Dictionary<string, int>();
            }
        }

        public int CreateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                var productCategory = mapper.Map<ProductCategory>(productCategoryViewModel);
                return productCategoryRepository.CreateProductCategory(productCategory);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
