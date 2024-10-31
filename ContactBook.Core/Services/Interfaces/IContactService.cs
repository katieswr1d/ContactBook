using ContactBook.Core.Entity;

namespace ContactBook.Core.Services;

public interface IContactService
{
    IEnumerable<Contact> ReadAll();
    void Create(Contact contact);
    IEnumerable<Contact> FindByAll(string firstName, string lastName, string phoneNumber, string email);
    
    IEnumerable<Contact> FindByFirstName(string firstName);
    IEnumerable<Contact> FindByLastName(string lastName);
    
    /// <summary>
    ///  метод для поиска по номеру телефона
    /// </summary>
    /// <param name="phoneNumber"> nomer telefona </param>
    /// <returns> vosrashaet kontact </returns>
    IEnumerable<Contact> FindByPhone(string phoneNumber);
    IEnumerable<Contact> FindByEmail(string email);
}