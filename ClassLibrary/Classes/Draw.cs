namespace ClassLibrary.Classes;

public class Draw
{
    public Draw(string serial, Person person)
    {
        Serial = serial;
        Person = person;
    }
    
    public Draw()
    {
    }

    public string Serial { get; set; }
    public Person Person { get; set; }
}