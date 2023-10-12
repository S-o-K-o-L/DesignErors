using System;
using System.Net;
using System.Net.Mail;

namespace SRP_False
{
    public class Customer //Причина для изменения - изменить добавление баланса, изменить логику отправки письма
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public void AddToBalance(decimal amount)
        {
            Balance += amount;
        }
        
        public void SendEmail(string message)
        {
            Console.WriteLine($"Письмо отправлено по адрессу {Name}: " + message);
        }
    }
}