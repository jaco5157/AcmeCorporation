using System.ComponentModel.DataAnnotations;
using ClassLibrary.Models;

namespace TestService;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Should_Return_Error_When_PersonIsUnder18()
    {
        // Arrange
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            DateOfBirth = DateTime.Now.AddYears(-16)
        };
        
        // Act
        var validationResults = ValidateModel(person);
        
        // Assert
        Assert.True(validationResults.Any(result => result.ErrorMessage == "You must be at least 18 years old to participate."));

    }
    
    [Test]
    public void Should_Validate_When_PersonIsOver18()
    {
        // Arrange
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            DateOfBirth = DateTime.Now.AddYears(-20)
        };
        
        // Act
        var validationResults = ValidateModel(person);
        
        // Assert
        Assert.IsEmpty(validationResults);
    }

    // Helper method to validate the model
    private IList<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
}