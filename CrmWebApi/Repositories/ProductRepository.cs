﻿using CrmWebApi.Domain.Core;
using CrmWebApi.Domain.DatabaseContext;
using CrmWebApi.Helpers;
using CrmWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CrmWebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            GuardClauses.IsNotNull(databaseContext, nameof(databaseContext));
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _databaseContext.Products.ToList();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return Enumerable.Empty<Product>();
            }
        }

        public string GetTheMostFrequentCategoryName()
        {
            try
            {
                return _databaseContext.Products
                    .GroupBy(product => product.Category.Name)
                    .Select(group => new {CategoryName = group.Key, Count = group.Count()})
                    .OrderByDescending(item => item.Count)
                    .FirstOrDefault()?.CategoryName;

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
