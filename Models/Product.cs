using System.Collections.Generic;

namespace RPKApp2.Models
{
    public class Product
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
        public bool IsActive { get; set; } = true;

        public Product()
        {
        }

        public Product(
            string id,
            string name,
            string description,
            decimal price,
            string category,
            int stock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Stock = stock;
            IsActive = true;
        }
    }
}