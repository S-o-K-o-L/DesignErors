using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleWithoutErrors
{
    class Program
    {
        public static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Поиск контакта");
                Console.WriteLine("3. Печать всех контактов");
                Console.WriteLine("4. Выйти");
                ;

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": //Добавление
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите номер телефона: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Введите тип: ");
                        string type = Console.ReadLine();
                        Contact newContact = new Contact { Name = name, PhoneNumber = phoneNumber, Type = type };
                        contactManager.AddContact(newContact);
                        Console.WriteLine("Контакт успешно добавлен.");
                        break;

                    case "2": //Поиск
                        Console.Write("Введите ключевое слово для поиска: ");
                        string keyword = Console.ReadLine();
                        List<Contact>
                            searchResultsOfContacts =
                                contactManager.SearchContacts(keyword); // Поиск по телефону или имени
                        Console.WriteLine("Результаты поиска:");
                        if (searchResultsOfContacts.Count == 0)
                        {
                            Console.WriteLine("Контакт(ы) не найдены.");
                        }
                        else
                        {
                            //Выводим в консоль
                            searchResultsOfContacts.ForEach(Console.WriteLine);
                        }

                        break;

                    case "3": // Печать всех контактов
                        List<Contact> allContacts = contactManager.GetAllContacts();
                        Console.WriteLine("Список всех контактов:");
                        allContacts.ForEach(Console.WriteLine); //Печатаем в консоль
                        break;

                    case "4": //Выход
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}