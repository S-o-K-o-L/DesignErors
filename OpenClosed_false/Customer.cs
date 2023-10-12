namespace OpenClosed_false
{
    public class Customer //Модификация класса - нарушение
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int LoyaltyPoints { get; set; }

        public void AddToBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}