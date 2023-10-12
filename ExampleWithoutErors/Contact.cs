

namespace ExampleWithoutErrors
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}, Телефон: {PhoneNumber}, Тип: {Type}";
        }
    }
}