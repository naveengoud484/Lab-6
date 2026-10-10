using System;
using System.Collections.Generic;
using System.Linq;

namespace productcatalog.Models
{
    /// <summary>
    /// Simple in-memory repository for Product model used by the sample app.
    /// Provides basic CRUD-like helpers for views and controllers.
    /// </summary>
    public static class ProductRepository
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Description = "Dell Laptop", Price = 55000m, Category = "Electronics" },
            new Product { ProductId = 2, ProductName = "Mobile", Description = "Samsung Mobile", Price = 25000m, Category = "Electronics" },
            new Product { ProductId = 3, ProductName = "Headphones", Description = "Wireless Headphones", Price = 3000m, Category = "Accessories" }
        };

        public static List<Product> GetAll()
        {
            return _products.ToList();
        }

        public static Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        public static Product Add(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var nextId = _products.Any() ? _products.Max(p => p.ProductId) + 1 : 1;
            product.ProductId = nextId;
            _products.Add(product);
            return product;
        }

        public static bool Remove(int id)
        {
            var p = GetById(id);
            if (p == null) return false;
            return _products.Remove(p);
        }

        public static void Update(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var existing = GetById(product.ProductId);
            if (existing == null) throw new InvalidOperationException("Product not found.");
            existing.ProductName = product.ProductName;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Category = product.Category;
        }
    }
}