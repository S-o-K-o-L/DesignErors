using System;

namespace SRP
{
    public class Customer //Причина для изменения - изменить добавление баланса
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public void AddToBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}