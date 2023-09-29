using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExampleWithErrors
{
    internal class Program
    {
        public static void Main(string[] args) //Код неподвижен - все в одном файле!!!!
        {
            string fileName = "contacts.txt"; // Имя файла по умолчанию

            Console.WriteLine(
                "Введите имя файла для загрузки контактов или оставьте поле пустым для использования файла по умолчанию (contacts.txt):");
            string inputFileName = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputFileName))
            {
                fileName = inputFileName;
            }

            List<Contact> contacts = new List<Contact>();
            
            using (StreamReader reader = new StreamReader(fileName)) //Загрузка данных из файла
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        string phoneNumber = parts[1];
                        Contact contact = new Contact { Name = name, PhoneNumber = phoneNumber };
                        contacts.Add(contact);
                    }
                }
            }

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
                        string imya = Console.ReadLine(); //Ошибка именования (плохая читабельность)
                        Console.Write("Введите номер телефона: ");
                        string nomer = Console.ReadLine(); //Ошибка именования (плохая читабельность)
                        Contact noviykontakt = new Contact { Name = imya, PhoneNumber = nomer }; //Ошибка именования и код стайла (плохая читабельность)
                        contacts.Add(noviykontakt);
                        Console.WriteLine("Контакт успешно добавлен.");
                        break;

                    case "2":
                        Console.Write("Введите ключевое слово для поиска: ");
                        string keyword = Console.ReadLine();
                        List<Contact> searchResults = contacts
                            .Where(contact => keyword != null && (contact.Name.Contains(keyword) || contact.PhoneNumber.Contains(keyword)))
                            .ToList();
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
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            foreach (var contact in contacts)
                            {
                                writer.WriteLine($"{contact.Name},{contact.PhoneNumber}");
                            }
                        }
                        Console.WriteLine($"Контакты успешно сохранены в файл {fileName}.");
                        break;
                    
                    case "4":
                        Console.WriteLine("Контакты из файла:");
                        List<Contact> loadedContacts = new List<Contact>();
                        using (StreamReader reader = new StreamReader(fileName)) //Ненужная повторяемость!!!
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] parts = line.Split(',');
                                if (parts.Length == 2)
                                {
                                    string name = parts[0];
                                    string phoneNumber = parts[1];
                                    Contact contact = new Contact { Name = name, PhoneNumber = phoneNumber };
                                    loadedContacts.Add(contact);
                                }
                            }
                        }
                        foreach (var contact in loadedContacts)
                        {
                            Console.WriteLine(contact);
                        }
                        break;

                    case "5":
                        
                        Console.WriteLine("Список всех контактов:");
                        foreach (var contact in contacts)
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