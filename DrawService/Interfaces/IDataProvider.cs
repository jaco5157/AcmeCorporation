using ClassLibrary.Models;

namespace DrawService.Interfaces;

public interface IDataProvider
{
    Draw? SubmitDraw(Draw draw);
    IEnumerable<Draw> ListDraws();
    bool ContainsSerialNumber(string serial);
    int GetUsageCount(string serial);
    bool IncrementUsageCount(string serial);
}