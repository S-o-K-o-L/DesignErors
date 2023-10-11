using System;
using System.Collections.Generic;
using System.IO;

namespace ExampleWithoutErrors
{
    public class FileManager : IInOutManager
    
    {
        private readonly string _filename;

        public FileManager(string filename)
        {
            _filename = filename;
        }

        public void WriteContacts(List<Contact> contacts)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filename)) //Открываем файл на запись с 1 строки
                {
                    foreach (var contact in contacts)
                    {
                        writer.WriteLine($"{contact.Name},{contact.PhoneNumber}");
                    }
                }
            }
            catch (Exception ex) // Если произошла какая-то ошибка - сообщаем об этом
            {
                Console.WriteLine("Ошибка записи файла контактов: " + ex.Message);
            }
        }

        public List<Contact> ReadContacts()
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                using (StreamReader reader = new StreamReader(_filename)) //Открываем файл на запись с 1 строки
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(','); //Данные в файле разделены запятой
                        if (parts.Length == 2)
                        {
                            string name = parts[0];
                            string phoneNumber = parts[1];
                            Contact contact = new Contact { Name = name, PhoneNumber = phoneNumber };
                            contacts.Add(contact);
                        }
                    }
                }
            }
            catch (Exception ex) // Если произошла какая-то ошибка - сообщаем об этом
            {
                Console.WriteLine("Ошибка чтения файла контактов: " + ex.Message);
            }

            return contacts;
        }
    }
}