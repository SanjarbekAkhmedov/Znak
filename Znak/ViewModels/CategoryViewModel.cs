﻿using Znak.Model.Entities;

namespace Znak.ViewModels
{
    public class CategoryViewModel
    {
        public ProductCategory ProductCategory { get; set; }

        public CategoryViewModel()
        {
            ProductCategories = new List<ProductCategory>();
        }

        public IEnumerable<ProductCategory> ProductCategories { get; set; }

        public IEnumerable<ProductCategory> Add(ProductCategory category)
        {
            ProductCategories.ToList().Add(category);
            return ProductCategories;
        }
    }
}
