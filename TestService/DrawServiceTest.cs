using ClassLibrary.Models;
using DrawService.Controllers;
using DrawService.DataProviders;
using Microsoft.Extensions.Logging;
using Moq;
using MySql.Data.MySqlClient;
using ThrowawayDb.MySql;

namespace TestService;

public class DrawServiceTest
{
    private ThrowawayDatabase _database;
    private ILogger<HomeController> _logger;
    private MySQLDataProvider _dataProvider;
    private HomeController _service;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _database = ThrowawayDatabase.Create(
            "root",
            "",
            "localhost"
        );

        using var con = new MySqlConnection(_database.ConnectionString);
        con.Open();
        var sql = @"CREATE TABLE Persons (
                        PersonId INT AUTO_INCREMENT PRIMARY KEY,
                        FirstName VARCHAR(100) NOT NULL,
                        LastName VARCHAR(100) NOT NULL,
                        Email VARCHAR(255) NOT NULL,
                        DateOfBirth DATE NOT NULL
                    );

                    CREATE TABLE SerialNumbers (
                        SerialNumber VARCHAR(100) PRIMARY KEY,
                        UsageCount INT DEFAULT 0
                    );

                    CREATE TABLE Draws (
                        DrawId INT AUTO_INCREMENT PRIMARY KEY,
                        EntryDate DATETIME DEFAULT NOW(),
                        WinningTicket BIT DEFAULT 0,
                        SerialNumber VARCHAR(100),
                        PersonId INT,
                        FOREIGN KEY (SerialNumber) REFERENCES SerialNumbers(SerialNumber),
                        FOREIGN KEY (PersonId) REFERENCES Persons(PersonId)
                    );

                    INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC649733', 0);
                    ";
        using var cmd = new MySqlCommand(sql, con);
        cmd.ExecuteNonQuery();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _database.Dispose();
    }

    [SetUp]
    public void Setup()
    {
        _database.CreateSnapshot();
        _logger = new Mock<ILogger<HomeController>>().Object;
        _dataProvider = new MySQLDataProvider();
        _dataProvider.setConnectionString(_database.ConnectionString);
        _service = new HomeController(_logger, _dataProvider);
    }

    [TearDown]
    public void Cleanup()
    {
        _database.RestoreSnapshot();
        _service.Dispose();
    }


    // ===== Get ===== //
    [Test]
    public void GetTest()
    {
        // Arrange

        // Act
        var result = _service.Get();

        // Assert
        Assert.That(result, Is.True);
    }
    
    // ===== SubmitDraw: Return null when using an invalid serial ===== //
    [Test]
    public void SubmitDraw_Returns_Null_When_Invalid_Serial()
    {
        // Arrange
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            DateOfBirth = DateTime.Now.AddYears(-20)
        };
        var invalid_serial = new Serial
        {
            SerialNumber = "AC111111"
        };
        var draw = new Draw
        {
            Person = person, 
            Serial = invalid_serial
        };

        // Act
        var result = _service.SubmitDraw(draw);

        // Assert
        Assert.That(result, Is.Null);
    }
    
    // ===== SubmitDraw: Return Draw when using a valid serial ===== //
    [Test]
    public void SubmitDraw_Returns_Draw_When_Valid_Serial()
    {
        // Arrange
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            DateOfBirth = DateTime.Now.AddYears(-20)
        };
        var serial = new Serial
        {
            SerialNumber = "AC649733"
        };
        var draw = new Draw
        {
            Person = person, 
            Serial = serial
        };

        // Act
        var result = _service.SubmitDraw(draw);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Serial.SerialNumber, Is.EqualTo("AC649733"));
    }
    
    // ===== SubmitDraw: Return null when using a valid serial three times / more than twice ===== //
    [Test]
    public void SubmitDraw_Returns_Null_When_Valid_Serial_Used_Thrice()
    {
        // Arrange
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            DateOfBirth = DateTime.Now.AddYears(-20)
        };
        var serial = new Serial
        {
            SerialNumber = "AC649733"
        };
        var draw = new Draw
        {
            Person = person, 
            Serial = serial
        };

        // Act and Assert
        var result = _service.SubmitDraw(draw);
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Serial.SerialNumber, Is.EqualTo("AC649733"));
        
        result = _service.SubmitDraw(draw);
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Serial.SerialNumber, Is.EqualTo("AC649733"));
        
        result = _service.SubmitDraw(draw);
        Assert.That(result, Is.Null);
    }
    
    // ===== ListDraws: Return Empty list when no draws have been submitted ===== //
    [Test]
    public void ListDraws_Returns_Empty_When_No_Draws_Submitted()
    {
        // Arrange

        // Act
        var result = _service.ListDraws();
        
        // Assert
        Assert.That(result, Is.Empty);
    }
    
    // ===== ListDraws: Return full list when draw have been submitted ===== //
    [Test]
    public void ListDraws_Returns_List_When_Draw_Submitted()
    {
        // Arrange
        var person = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            DateOfBirth = DateTime.Now.AddYears(-20)
        };
        var serial = new Serial
        {
            SerialNumber = "AC649733"
        };
        var draw = new Draw
        {
            Person = person, 
            Serial = serial
        };

        // Act
        _service.SubmitDraw(draw);
        var result = _service.ListDraws();
        
        // Assert
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.First().Serial.SerialNumber, Is.EqualTo("AC649733"));
    }
    
    // ===== ValidateSerialNumber: Return false when invalid serial ===== //
    [Test]
    public void ValidateSerialNumber_Returns_False_When_Invalid_Serial()
    {
        // Arrange
        var serialNumber = "AC111111";

        // Act
        var result = _service.ValidateSerialNumber(serialNumber);
        
        // Assert
        Assert.That(result, Is.False);
    }
    
    // ===== ValidateSerialNumber: Return true when valid serial ===== //
    [Test]
    public void ValidateSerialNumber_Returns_True_When_Valid_Serial()
    {
        // Arrange
        var serialNumber = "AC649733";

        // Act
        var result = _service.ValidateSerialNumber(serialNumber);
        
        // Assert
        Assert.That(result, Is.True);
    }
}