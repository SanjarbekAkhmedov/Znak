﻿using Znak.Model.Entities;

namespace Znak.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public ProductViewModel()
        {
            Products = new List<Product>();
        }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Product> Add(Product product)
        {
            Products.ToList().Add(product);
            return Products;
        }
    }
}
