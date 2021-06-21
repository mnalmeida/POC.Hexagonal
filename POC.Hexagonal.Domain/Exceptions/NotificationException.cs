using Flunt.Notifications;
using System.Collections.Generic;

namespace POC.Hexagonal.Domain.Exceptions
{
    public class NotificationException : DomainException
    {
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        public NotificationException(IReadOnlyCollection<Notification>  notifications)
        {
            Notifications = notifications;
        }
    }
}