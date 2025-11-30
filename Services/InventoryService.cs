using System;
using System.Collections.Generic;
using System.Linq;
using RPKApp2.Models;

namespace RPKApp2.Services
{
    public class InventoryService
    {
        private readonly List<Product> _products = new();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product? GetById(string productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public void EnsureInStock(string productId, int quantity)
        {
            var product = GetById(productId);

            if (product == null)
            {
                throw new OutOfStockException(productId, $"Product {productId} not found.");
            }

            if (product.Stock < quantity)
            {
                throw new OutOfStockException(productId, $"Product {productId} is out of stock.");
            }
        }

        public void DecreaseStock(string productId, int quantity)
        {
            var product = GetById(productId);

            if (product == null)
            {
                throw new InvalidOperationException($"Product {productId} not found.");
            }

            product.Stock -= quantity;
        }

        public int GetStock(string productId)
        {
            var product = GetById(productId);
            return product?.Stock ?? 0;
        }
    }
}