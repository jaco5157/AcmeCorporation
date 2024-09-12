using ClassLibrary.Models;

namespace Frontend.Models;

public class DrawListViewModel
{
    public IEnumerable<Draw> Draws { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}