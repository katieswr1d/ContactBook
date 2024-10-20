namespace ContactBook.Core.Entity;

public class Email
{
    public int Id { get; set; } //для идентификации емейлов у пользователя
    public string Value { get; set; }

    public override string ToString()
    {
        return Value;
    }
}