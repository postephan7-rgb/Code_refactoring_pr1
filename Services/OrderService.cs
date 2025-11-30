using System;
using System.Collections.Generic;
using RPKApp2.Infrastructure;
using RPKApp2.Models;

namespace RPKApp2.Services
{
    public class OrderService
    {
        private readonly InventoryService _inventoryService;
        private readonly InMemoryDatabase _database;
        private readonly NotificationService _notificationService;

        public OrderService(
            InventoryService inventoryService,
            InMemoryDatabase database,
            NotificationService notificationService)
        {
            _inventoryService = inventoryService;
            _database = database;
            _notificationService = notificationService;
        }

        public Order PlaceOrder(User user, List<OrderItem> items)
        {
            ValidateItemsAvailability(items);
            UpdateInventory(items);

            var order = new Order(user, items)
            {
                Status = OrderStatus.Pending
            };

            order = _database.SaveOrder(order);

            _notificationService.NotifyOrderPlaced(order);
            LogOrderPlaced(order);

            return order;
        }

        private void ValidateItemsAvailability(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                _inventoryService.EnsureInStock(item.Product.Id, item.Quantity);
            }
        }

        private void UpdateInventory(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                _inventoryService.DecreaseStock(item.Product.Id, item.Quantity);
            }
        }

        private void LogOrderPlaced(Order order)
        {
            Console.WriteLine($"Order placed: {order.Id}");
        }
    }
}