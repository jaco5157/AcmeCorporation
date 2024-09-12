using ClassLibrary.Models;
using DrawService.Interfaces;
using MySql.Data.MySqlClient;

namespace DrawService.DataProviders;

public class MySQLDataProvider : IDataProvider
{
    private string cs = @"server=database.draw;userid=root;password=;database=db";
    public void setConnectionString(string connectionString) => cs = connectionString;
    private readonly ILogger<MySQLDataProvider>? _logger;

    public MySQLDataProvider(ILogger<MySQLDataProvider>? logger = null)
    {
        _logger = logger;
    }
    
    private bool Open(MySqlConnection con)
    {
        try
        {
            con.Open();
            return true;
        }
        catch (Exception err)
        {
            _logger?.LogError(err, "Failed to connect to DB");
            return false;
        }
    }
    
    
    
    
    
    public Draw? SubmitDraw(Draw draw)
    {
        var personId = GetOrCreatePerson(draw.Person);
        
        using var con = new MySqlConnection(cs);
        if (!Open(con))
            return null;

        var sql = @"INSERT INTO Draws(WinningTicket, SerialNumber, PersonId) 
                    VALUES(@winningticket, @serialnumber, @personid)";
        using var cmd = new MySqlCommand(sql, con);
        
        cmd.Parameters.AddWithValue("@winningticket", draw.WinningTicket);
        cmd.Parameters.AddWithValue("@serialnumber", draw.Serial.SerialNumber);
        cmd.Parameters.AddWithValue("@personid", personId);
        
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        
        sql = "SELECT LAST_INSERT_ID()";
        using var getIdCmd = new MySqlCommand(sql, con);
        var result = GetDrawById(Convert.ToInt32(getIdCmd.ExecuteScalar()));

        return result;
    }

    public IEnumerable<Draw> ListDraws()
    {
        var draws = new List<Draw>();

        using var con = new MySqlConnection(cs);
        if (!Open(con))
            return draws;

        var sql = @"SELECT d.DrawId, d.EntryDate, d.WinningTicket, s.SerialNumber, s.UsageCount, 
                       p.FirstName, p.LastName, p.Email, p.DateOfBirth
                FROM Draws d
                JOIN Persons p ON d.PersonId = p.PersonId
                JOIN SerialNumbers s ON d.SerialNumber = s.SerialNumber";
    
        using var cmd = new MySqlCommand(sql, con);
    
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var person = new Person(
                reader.GetString("FirstName"),
                reader.GetString("LastName"),
                reader.GetString("Email"),
                reader.GetDateTime("DateOfBirth"));

            var serial = new Serial(
                reader.GetString("SerialNumber"),
                reader.GetInt32("UsageCount"));

            var draw = new Draw(
                reader.GetInt32("DrawId"),
                reader.GetDateTime("EntryDate"),
                reader.GetBoolean("WinningTicket"),
                serial,
                person);
        
            draws.Add(draw);
        }

        return draws;
    }

    public bool ContainsSerialNumber(string serial)
    {
        using var con = new MySqlConnection(cs);
        if (!Open(con))
            return false;
        
        var sql = @"SELECT COUNT(*) FROM SerialNumbers WHERE SerialNumber = @serial";
        using var cmd = new MySqlCommand(sql, con);
        
        cmd.Parameters.AddWithValue("@serial", serial);
        cmd.Prepare();
        
        var result = cmd.ExecuteScalar();
        
        if (result != null && int.TryParse(result.ToString(), out var count))
        {
            return count > 0;
        }

        return false;
    }

    public int GetUsageCount(string serial)
    {
        using var con = new MySqlConnection(cs);
        if (!Open(con))
            return 99;
        
        var sql = @"SELECT UsageCount FROM SerialNumbers WHERE SerialNumber = @serial";
        using var cmd = new MySqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@serial", serial);
        cmd.Prepare();
        var result = cmd.ExecuteScalar();
        
        if (result != null && int.TryParse(result.ToString(), out var usageCount))
        {
            return usageCount;
        }

        return 99;
    }
    
    public bool IncrementUsageCount(string serial)
    {
        using var con = new MySqlConnection(cs);
        if (!Open(con))
            return false;
        
        var sql = @"UPDATE SerialNumbers SET UsageCount = UsageCount + 1 WHERE SerialNumber = @serial";
        using var cmd = new MySqlCommand(sql, con);
        
        cmd.Parameters.AddWithValue("@serial", serial);
        cmd.Prepare();

        var rowsAffected = cmd.ExecuteNonQuery();

        return rowsAffected > 0;
    }


    
    
    
    
    private int GetOrCreatePerson(Person person)
    {
        using var con = new MySqlConnection(cs);
        if (!Open(con))
            return 0;
        
        // Check if person exists
        var checkSql = @"SELECT PersonId FROM Persons 
                     WHERE Firstname = @firstname 
                       AND Lastname = @lastname 
                       AND Email = @email 
                       AND DateOfBirth = @dateofbirth";
        using var checkCmd = new MySqlCommand(checkSql, con);
        checkCmd.Parameters.AddWithValue("@firstname", person.FirstName);
        checkCmd.Parameters.AddWithValue("@lastname", person.LastName);
        checkCmd.Parameters.AddWithValue("@email", person.Email);
        checkCmd.Parameters.AddWithValue("@dateofbirth", person.DateOfBirth);
        checkCmd.Prepare();

        if (checkCmd.ExecuteScalar() is int existingId)
        {
            return existingId;
        }
        
        
        // Create person and return ID if they do not exist
        var sql = @"INSERT INTO Persons(Firstname, Lastname, Email, DateOfBirth) 
                    VALUES(@firstname, @lastname, @email, @dateofbirth)";
        using var cmd = new MySqlCommand(sql, con);
        
        cmd.Parameters.AddWithValue("@firstname", person.FirstName);
        cmd.Parameters.AddWithValue("@lastname", person.LastName);
        cmd.Parameters.AddWithValue("@email", person.Email);
        cmd.Parameters.AddWithValue("@dateofbirth", person.DateOfBirth);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        
        sql = "SELECT LAST_INSERT_ID()";
        using var idCmd = new MySqlCommand(sql, con);
        var result = Convert.ToInt32(idCmd.ExecuteScalar());

        return result;
    }
    
    
    private Draw? GetDrawById(int id)
    {
        using var con = new MySqlConnection(cs);
        if (!Open(con))
            return null;
        
        var sql = @"
        SELECT 
            d.DrawId,
            d.EntryDate,
            d.WinningTicket,
            s.SerialNumber,
            s.UsageCount,
            p.FirstName,
            p.LastName,
            p.Email,
            p.DateOfBirth
        FROM Draws d
        INNER JOIN SerialNumbers s ON d.SerialNumber = s.SerialNumber
        INNER JOIN Persons p ON d.PersonId = p.PersonId
        WHERE d.DrawId = @id";
        
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Prepare();
        
        using MySqlDataReader reader = cmd.ExecuteReader();

        if (!reader.Read()) return null;
        var person = new Person(
            reader.GetString("FirstName"),
            reader.GetString("LastName"),
            reader.GetString("Email"),
            reader.GetMySqlDateTime("DateOfBirth").Value);

        var serial = new Serial(
            reader.GetString("SerialNumber"),
            reader.GetInt32("UsageCount"));

        var draw = new Draw(
            reader.GetInt32("DrawId"),
            reader.GetMySqlDateTime("EntryDate").Value,
            reader.GetBoolean("WinningTicket"),
            serial,
            person);

        return draw;

    }
}