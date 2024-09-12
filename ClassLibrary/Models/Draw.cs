using System.ComponentModel;

namespace ClassLibrary.Models;

public class Draw
{
    public Draw(int id, DateTime entryDate, bool winningTicket, Serial serial, Person person)
    {
        Id = id;
        EntryDate = entryDate;
        WinningTicket = winningTicket;
        Serial = serial;
        Person = person;
    }
    
    public Draw()
    {
    }
    
    public int Id { get; set; }
    public Serial Serial { get; set; }
    public Person Person { get; set; }
    
    [DisplayName("Winning ticket")]
    public bool WinningTicket { get; set; }
    
    [DisplayName("Entry data")]
    public DateTime EntryDate { get; set; }
}
