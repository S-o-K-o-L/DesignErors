namespace ExampleWithErrors
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}, Телефон: {PhoneNumber}";
        }
    }
}