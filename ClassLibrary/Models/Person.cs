using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    
    [DisplayName("Date of birth")]
    [Over18]
    public DateTime DateOfBirth { get; set; }
}

public class Over18Attribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateOfBirth)
        {
            var age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
            
            if (age < 18)
            {
                return new ValidationResult(ErrorMessage ?? "You must be at least 18 years old to participate.");
            }
        }

        return ValidationResult.Success;
    }
}