using System.Collections.Generic;

namespace ExampleWithoutErrors
{
    public interface IInOutManager
    {
        List<Contact> ReadContacts();
        void WriteContacts(List<Contact> contacts);
    }
}