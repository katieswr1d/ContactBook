namespace ContactBook.Core.Entity;

public class PhoneNumber
{
    public string  Value { get; set; }
    public override string ToString() {
        return Value;
    }
}