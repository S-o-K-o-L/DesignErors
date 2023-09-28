using System;
using System.Collections.Generic;

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
                        List<Contact> searchResults = contactManager.SearchContacts(keyword);
                        Console.WriteLine("Результаты поиска:");
                        if (searchResults.Count == 0)
                        {
                            Console.WriteLine("Контактов не найдено.");
                        }
                        else
                        {
                            foreach (var contact in searchResults)
                            {
                                Console.WriteLine(contact);
                            }
                        }
                        break;

                    case "3":
                        contactManager.SaveContactsToFile(fileName);
                        Console.WriteLine($"Контакты успешно сохранены в файл {fileName}.");
                        break;
                    
                    case "4":
                        Console.WriteLine("Контакты из файла:");
                        List<Contact> loadedContacts = contactManager.GetAllContacts();
                        foreach (var contact in loadedContacts)
                        {
                            Console.WriteLine(contact);
                        }
                        break;

                    case "5":
                        List<Contact> allContacts = contactManager.GetAllContacts();
                        Console.WriteLine("Список всех контактов:");
                        foreach (var contact in allContacts)
                        {
                            Console.WriteLine(contact);
                        }
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