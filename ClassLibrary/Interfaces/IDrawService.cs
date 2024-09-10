using ClassLibrary.Classes;

namespace ClassLibrary.Interfaces;

public interface IDrawService
{
    public bool Get();
    public Draw? DrawEntry(Draw draw);
    public IEnumerable<Draw> ListEntries(string email);
}