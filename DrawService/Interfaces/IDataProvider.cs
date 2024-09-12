using ClassLibrary.Models;

namespace DrawService.Interfaces;

public interface IDataProvider
{
    Draw? SubmitDraw(Draw draw);
    IEnumerable<Draw> ListDraws();
    bool ContainsSerialNumber(string serial);
    bool GetDrawCount(string serial);
    int GetOrCreatePerson(Person person);
}