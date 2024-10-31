using ContactBook.Core.Entity;

namespace ContactBook.DAL;

public interface IRepositoty
{
    IEnumerable<Contact> ReadAll();
    IEnumerable<Contact> FilterContacts(Predicate<Contact> filter);
    Task Create(Contact contact);
}