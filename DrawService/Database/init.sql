CREATE DATABASE db;
USE db;

CREATE TABLE Persons (
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
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC663579', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC447486', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC546973', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC659722', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC363642', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC278374', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC934735', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC563426', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC846957', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC823874', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC585247', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC684665', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC462793', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC266242', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC726937', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC794395', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC595424', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC464244', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC246733', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC945347', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC552427', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC842948', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC935529', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC463582', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC768358', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC779689', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC958234', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC637776', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC799973', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC329285', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC894643', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC496388', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC442579', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC249279', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC577224', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC827944', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC572379', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC369495', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC796522', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC796872', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC399747', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC232229', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC556282', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC748534', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC959693', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC522467', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC349664', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC349767', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC267743', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC345922', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC783953', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC878492', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC583444', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC582727', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC424324', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC993874', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC253594', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC669552', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC636565', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC786579', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC983946', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC722956', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC365683', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC474744', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC396959', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC695988', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC236559', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC322363', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC233392', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC772973', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC724696', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC824792', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC286987', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC438772', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC578955', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC573533', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC584537', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC447363', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC674252', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC663384', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC553768', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC229794', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC984836', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC838468', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC579394', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC239455', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC757378', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC969764', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC355394', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC655865', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC998638', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC684532', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC735458', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC633443', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC356752', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC998556', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC864888', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC452378', 0);
INSERT INTO SerialNumbers (SerialNumber, UsageCount) VALUES ('AC575689', 0);

ALTER user 'root' IDENTIFIED WITH mysql_native_password BY '';
flush privileges;