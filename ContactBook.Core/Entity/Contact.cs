namespace ContactBook.Core.Entity;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;//чтобы была статическая пустая строка а не создавалось миллион этих строк
    public string LastName { get; set; } = string.Empty;
    public List<Email> Email { get; set; } = [];
    public List<PhoneNumber> PhoneNumber { get; set; } = [];

    public override string ToString() {
        return "First Name: " + FirstName + "\nLast Name: " + LastName + 
               "\nEmails: " + string.Join("\n", Email) + "\nPhoneNumbers: " + 
               string.Join("\n", PhoneNumber);
    }
}