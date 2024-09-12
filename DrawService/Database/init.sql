CREATE TABLE Persons (
    PersonId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    DateOfBirth DATE NOT NULL
);

CREATE TABLE SerialNumbers (
    SerialNumber VARCHAR(100) PRIMARY KEY,
    UsageCount INT DEFAULT 0
);

CREATE TABLE Draws (
    DrawId INT IDENTITY(1,1) PRIMARY KEY,
    EntryDate DATETIME DEFAULT GETDATE(),
    WinningTicket BIT DEFAULT 0,
    FOREIGN KEY (SerialNumber) REFERENCES SerialNumbers(SerialNumber),
    FOREIGN KEY (PersonId) REFERENCES Persons(PersonId)
);