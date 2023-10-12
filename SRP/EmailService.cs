using System;

namespace SRP
{
    public class EmailService // Причина для изменения - добавить новую реализацию отправки писем
    {
        public static void SendEmail(Customer customer, string message)
        {
            Console.WriteLine($"Письмо отправлено по адрессу {customer.Name}: " + message);
        }
    }
}