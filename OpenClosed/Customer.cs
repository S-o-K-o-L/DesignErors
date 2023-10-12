namespace OpenClosed
{
    public class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public void AddToBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}