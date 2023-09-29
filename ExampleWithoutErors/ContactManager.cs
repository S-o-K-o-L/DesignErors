using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExampleWithoutErrors
{
    public class ContactManager
    {
        private List<Contact> contacts;

        public ContactManager(string fileName)
        {
            contacts = LoadContactsFromFile(fileName);
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public List<Contact> SearchContacts(string keyword)
        {
            return contacts.Where(contact => contact.Name.Contains(keyword)
                                             || contact.PhoneNumber.Contains(keyword))
                .ToList();
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public void SaveContactsToFile(string fileName)
        {
            IInOutManager fileManger = new FileManager(fileName);
            fileManger.WriteContacts(contacts);
        }

        public List<Contact> LoadContactsFromFile(string fileName)
        {
            IInOutManager fileManger = new FileManager(fileName);
            return fileManger.ReadContacts();
        }
    }
}