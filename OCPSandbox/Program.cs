namespace OCPExample
{
    public class NotificationService
    {
        public void Notify(string type, string message)
        {
            var notification = NotificationFactory.Create(type);
            notification.SendNotification(message); // directly use the factory object
        }
    }

    public interface INotification
    {
        public void SendNotification(string message);
    }

    class EmailNotification : INotification
    {
        public void  SendNotification( string message) {
            Console.WriteLine("Sending Email: " + message);
        }
    }

    class SmsNotification : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Sending SMS: " + message);
        }
    }

    class PushNotification : INotification {
        public void SendNotification(string message)
        {
            Console.WriteLine("Sending Push Notification: " + message);
        }
    }

    ///factory
    public class NotificationFactory
    {
        public static INotification Create(string type)
        {
            return type switch
            {
                "Email" => new EmailNotification(),
                "SMS" => new SmsNotification(),
                "Push" => new PushNotification(),
                _ => throw new ArgumentException("Unknown notification type")
            };
        }
    }
}


