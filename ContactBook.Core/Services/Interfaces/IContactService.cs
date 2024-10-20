using ContactBook.Core.Entity;

namespace ContactBook.Core.Services;

public interface IContactService
{
    IEnumerable<Contact> ReadAll();
    void Create(Contact contact);
    IEnumerable<Contact> FindByAll(string firstName, string lastName, string phoneNumber, string email);
    
    IEnumerable<Contact> FindByFirstName(string firstName);
    IEnumerable<Contact> FindByLastName(string lastName);
    IEnumerable<Contact> FindByPhone(string phoneNumber);
    IEnumerable<Contact> FindByEmail(string email);
}