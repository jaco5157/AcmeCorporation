using ClassLibrary.Models;
using DrawService.Interfaces;

namespace DrawService.DataProviders;

public class MySQLDataProvider : IDataProvider
{
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