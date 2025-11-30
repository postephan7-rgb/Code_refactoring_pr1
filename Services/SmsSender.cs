using System;
using RPKApp2.Models;

namespace RPKApp2.Infrastructure
{
    public class SmsSender
    {
        public void SendOrderConfirmation(string? phone, Order order)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return;
            }

            Console.WriteLine($"Sending SMS to {phone}: Your order {order.Id} is placed.");
        }
    }
}