using System;

namespace RPKApp2.Models
{
    public class OutOfStockException : Exception
    {
        public string ProductId { get; }

        public OutOfStockException(string productId, string message)
            : base(message)
        {
            ProductId = productId;
        }
    }
}