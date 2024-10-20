using System.Net;
using System.Text.Json;
using ContactBook.Core.Entity;
using ContactBook.DAL.Repositories;

namespace ContactBook.DAL.Repositories;

public class FileRepository : IRepositoty
{
    private List<Contact> _contacts;

    public FileRepository()
    {
        if (!File.Exists("contacts.json"))
        {
            _contacts = [];
        }
        else _contacts = JsonSerializer.Deserialize<List<Contact>>(File.ReadAllText("contacts.json")); //считываем из файла и конвертируем в коллекцию;
        
    }
    public IEnumerable<Contact> ReadAll() //метод для чтения всех контактов
    {
        return _contacts;
    }

    public IEnumerable<Contact> FilterContacts(Predicate<Contact> filter)
    {
        var res = new List<Contact>();

        foreach (var contact in _contacts) {
            if (filter(contact)) {
                res.Add(contact);
            }
        }
        return res;
    }
    public void Create(Contact contact)
    {
        _contacts.Add(contact);
        File.WriteAllText("contacts.json", JsonSerializer.Serialize(_contacts));//запись и конвертация контакта на диск в определенном формате 
        
    }
}