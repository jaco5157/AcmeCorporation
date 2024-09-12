using System.ComponentModel;

namespace ClassLibrary.Models;

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

    [DisplayName("Serial number")]
    public string Serial { get; set; }
    public Person Person { get; set; }
    
    [DisplayName("Winning ticket")]
    public bool WinningTicket { get; set; }
}
