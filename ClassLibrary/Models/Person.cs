using System.ComponentModel;

namespace ClassLibrary.Models;

public class Person
{
    public Person(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
    
    public Person()
    {
    }

    [DisplayName("First name")]
    public string FirstName { get; set; }
    
    [DisplayName("Last name")]
    public string LastName { get; set; }
    
    [DisplayName("Email address")]
    public string Email { get; set; }
}