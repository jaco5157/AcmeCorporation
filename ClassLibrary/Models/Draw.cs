using System.ComponentModel;

namespace ClassLibrary.Models;

public class Draw
{
    public Draw(Serial serial, Person person)
    {
        Serial = serial;
        Person = person;
    }
    
    public Draw()
    {
    }
    
    public Serial Serial { get; set; }
    public Person Person { get; set; }
    
    [DisplayName("Winning ticket")]
    public bool WinningTicket { get; set; }
}
