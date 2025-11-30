using RPKApp2.Infrastructure;
using RPKApp2.Models;

namespace RPKApp2.Services
{
    public class NotificationService
    {
        private readonly EmailSender _emailSender;
        private readonly SmsSender _smsSender;

        public NotificationService(EmailSender emailSender, SmsSender smsSender)
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        public void NotifyOrderPlaced(Order order)
        {
            _emailSender.SendOrderConfirmation(order.User.Email, order);
            _smsSender.SendOrderConfirmation(order.User.Phone, order);
        }
    }
}