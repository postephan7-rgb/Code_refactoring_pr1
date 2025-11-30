using System;
using RPKApp2.Models;

namespace RPKApp2.Infrastructure
{
    public class EmailSender
    {
        public void SendOrderConfirmation(string email, Order order)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return;
            }

            Console.WriteLine($"Sending email to: {email}");
            Console.WriteLine("Subject: Your order is placed!");
            Console.WriteLine($"Text: Your order {order.Id} has been placed.");
        }
    }
}