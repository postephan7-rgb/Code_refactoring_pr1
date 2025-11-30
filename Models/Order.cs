using System.Collections.Generic;

namespace RPKApp2.Models
{
    public class Order
    {
        public string Id { get; set; } = string.Empty;
        public User User { get; set; }
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public Order(User user, List<OrderItem> items)
        {
            User = user;
            Items = items;
        }
    }
}