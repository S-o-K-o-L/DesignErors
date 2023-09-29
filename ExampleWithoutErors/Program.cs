using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleWithoutErrors
{
    class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "contacts.txt"; // Имя файла по умолчанию
            
            Console.WriteLine(
                "Введите имя файла для загрузки контактов или оставьте поле пустым для использования файла по умолчанию (contacts.txt):");
            string inputFileName = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputFileName))
            {
                fileName = inputFileName;
            }

            ContactManager contactManager = new ContactManager(fileName);
            IInOutManager consoleManager = new ConsoleManager();
            
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Поиск контакта");
                Console.WriteLine("3. Сохранить контакты в файл");
                Console.WriteLine("4. Вывести контакты из файла");
                Console.WriteLine("5. Печать всех контактов");
                Console.WriteLine("6. Выйти");;

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите номер телефона: ");
                        string phoneNumber = Console.ReadLine();
                        Contact newContact = new Contact { Name = name, PhoneNumber = phoneNumber };
                        contactManager.AddContact(newContact);
                        Console.WriteLine("Контакт успешно добавлен.");
                        break;

                    case "2":
                        Console.Write("Введите ключевое слово для поиска: ");
                        string keyword = Console.ReadLine();
                        List<Contact> searchResultsOfContacts = contactManager.SearchContacts(keyword); // Поиск по телефону или имени
                        Console.WriteLine("Результаты поиска:");
                        if (searchResultsOfContacts.Count == 0)
                        {
                            Console.WriteLine("Контактов не найдено.");
                        }
                        else
                        {
                            searchResultsOfContacts.ForEach(Console.WriteLine);
                        }
                        break;

                    case "3":
                        contactManager.SaveContactsToFile(fileName);
                        Console.WriteLine($"Контакты успешно сохранены в файл {fileName}.");
                        break;
                    
                    case "4":
                        Console.WriteLine("Контакты из файла:");
                        List<Contact> loadedContacts = contactManager.LoadContactsFromFile(fileName);
                        Console.WriteLine("Список всех контактов:");
                        consoleManager.WriteContacts(loadedContacts);
                        break;

                    case "5":
                        List<Contact> allContacts = contactManager.GetAllContacts();
                        Console.WriteLine("Список всех контактов:");
                        consoleManager.WriteContacts(allContacts);
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}