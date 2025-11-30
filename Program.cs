using System;
using System.Collections.Generic;
using RPKApp2.Models;
using RPKApp2.Services;
using RPKApp2.Infrastructure;

namespace RPKApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Инициализация инфраструктуры и сервисов ---
            var inventoryService = new InventoryService();
            var database = new InMemoryDatabase();
            var emailSender = new EmailSender();
            var smsSender = new SmsSender();
            var notificationService = new NotificationService(emailSender, smsSender);
            var orderService = new OrderService(inventoryService, database, notificationService);

            // --- Инициализация инвентаря ---
            var product1 = new Product(
                id: "prod1",
                name: "Laptop",
                description: "Gaming laptop",
                price: 999.99m,
                category: "Electronics",
                stock: 10
            );

            inventoryService.AddProduct(product1);

            // --- Создание пользователя ---
            var user = new User(
                id: "user1",
                email: "user@example.com",
                phone: "123-456-7890"
            );

            // --- Создание заказа ---
            var items = new List<OrderItem>
            {
                new OrderItem(product1, quantity: 2)
            };

            try
            {
                var order = orderService.PlaceOrder(user, items);
                Console.WriteLine($"Order created: {order.Id}");
            }
            catch (OutOfStockException ex)
            {
                Console.WriteLine($"Not enough stock: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // --- Пример создания продукта через отдельный метод ---
            var product = CreateProduct(
                name: "Laptop",
                description: "Gaming laptop",
                price: 999.99m,
                category: "Electronics",
                stock: 5,
                supplier: "TechSupplier",
                tags: new List<string> { "gaming", "laptop", "electronics" },
                isActive: true
            );

            Console.WriteLine($"Product created: {product.Name}");
        }

        public static Product CreateProduct(
            string name,
            string description,
            decimal price,
            string category,
            int stock,
            string supplier,
            List<string> tags,
            bool isActive)
        {
            return new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                Stock = stock,
                Supplier = supplier,
                Tags = tags,
                IsActive = isActive
            };
        }
    }
}