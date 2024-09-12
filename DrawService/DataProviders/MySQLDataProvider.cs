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
        throw new NotImplementedException();
    }

    public IEnumerable<Draw> ListDraws()
    {
        throw new NotImplementedException();
    }

    public bool ContainsSerialNumber(string serial)
    {
        throw new NotImplementedException();
    }

    public int GetDrawCount(string serial)
    {
        throw new NotImplementedException();
    }

    public int GetOrCreatePerson(Person person)
    {
        throw new NotImplementedException();
    }
}