using System.Text.Json;
using ContactBook.Core.Entity;

namespace ContactBook.DAL.Repositories;

public class FileRepository : IRepositoty
{
    private const string ContactsJson = "contacts.json";
    private List<Contact> _contacts;
    
    public FileRepository()
    {
        InitializeAsync().GetAwaiter().GetResult();
    }

    private async Task InitializeAsync()
    {
        _contacts = await LoadContactsFromFile();
    }

    private async Task<List<Contact>> LoadContactsFromFile()
    {
        if (!File.Exists(ContactsJson))
        {
            return []; // возвращаем пустой список, если файл не существует
        }

        var json = await File.ReadAllTextAsync(ContactsJson);
        return JsonSerializer.Deserialize<List<Contact>>(json)!; // десериализуем файл в коллекцию
    }
    
    public IEnumerable<Contact> ReadAll() //метод для чтения всех контактов (конкретный репозиторий, который читает данные из конкретного места)
    {
        return _contacts;
    }

    public IEnumerable<Contact> FilterContacts(Predicate<Contact> filter)
    {
        return _contacts.Where(contact => filter(contact)).ToList();
    }
    public async Task Create(Contact contact)
    {
        _contacts.Add(contact);
        await File.WriteAllTextAsync(ContactsJson, JsonSerializer.Serialize(_contacts));//запись и конвертация контакта на диск в определенном формате 
        
    }
}