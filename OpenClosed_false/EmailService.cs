using System;

namespace OpenClosed_false
{
    public class EmailService
    {
        public static void SendEmail(Customer customer, string message)
        {
            Console.WriteLine($"Письмо отправлено по адрессу {customer.Name}: " + message);
        }
    }
}