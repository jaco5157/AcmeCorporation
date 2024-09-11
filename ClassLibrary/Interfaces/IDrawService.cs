using ClassLibrary.Models;

namespace ClassLibrary.Interfaces;

public interface IDrawService
{
    public bool Get();
    public Draw? SubmitDraw(Draw draw);
    public IEnumerable<Draw> ListDraws(string email);
}