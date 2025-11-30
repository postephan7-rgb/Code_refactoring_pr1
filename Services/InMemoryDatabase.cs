using System;
using System.Collections.Generic;
using RPKApp2.Models;

namespace RPKApp2.Infrastructure
{
    public class InMemoryDatabase
    {
        private readonly List<Order> _orders = new();

        public Order SaveOrder(Order order)
        {
            if (string.IsNullOrWhiteSpace(order.Id))
            {
                order.Id = Guid.NewGuid().ToString();
            }

            _orders.Add(order);
            return order;
        }

        public IReadOnlyList<Order> GetAllOrders()
        {
            return _orders.AsReadOnly();
        }
    }
}