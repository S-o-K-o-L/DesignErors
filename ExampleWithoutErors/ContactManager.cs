using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExampleWithoutErrors
{
    public class ContactManager
    {
        private List<Contact> contacts;
        
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public List<Contact> SearchContacts(string keyword) //Поиск по ключевому слову
        {
            return contacts.Where(contact => contact.Name.Contains(keyword)
                                             || contact.PhoneNumber.Contains(keyword))
                .ToList();
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }
    }
}