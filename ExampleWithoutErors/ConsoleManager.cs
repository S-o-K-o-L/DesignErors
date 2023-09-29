using System;
using System.Collections.Generic;
using System.IO;

namespace ExampleWithoutErrors
{
    public class ConsoleManager : IInOutManager
    {
        public void WriteContacts(List<Contact> contacts)
        {
            contacts.ForEach(Console.WriteLine);
        }

        public List<Contact> ReadContacts()
        {
            List<Contact> contacts = new List<Contact>();
            bool isContinue = true;
            while (isContinue)
            {
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите номер телефона: ");
                string phoneNumber = Console.ReadLine();
                Contact newContact = new Contact { Name = name, PhoneNumber = phoneNumber };
                contacts.Add(newContact);
                Console.Write("Продолжаем? (y, n)");
                string answer = Console.ReadLine();
                if (answer != null)
                {
                    isContinue = answer.Equals("y");
                }
            }
            return contacts;
        }
    }
}