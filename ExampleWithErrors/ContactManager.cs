using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    
    public class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();
        private string fileName;
        
        public ContactManager(string fileName)
        {
            this.fileName = fileName;
            if (File.Exists(fileName))
            {
                LoadContactsFromFile(fileName);
            }
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public List<Contact> SearchContacts(string keyword)
        {
            return contacts.Where(contact => contact.Name.Contains(keyword) || contact.PhoneNumber.Contains(keyword))
                .ToList();
        }
        
        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public void SaveContactsToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.Name},{contact.PhoneNumber}");
                }
            }
        }

        private void LoadContactsFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
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
        }
    }
}