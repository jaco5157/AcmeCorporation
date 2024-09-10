using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Classes;

namespace Frontend.Models;

public class DrawModel
{
    [BindProperty]
    public Person Person { get; set; }
    
    [BindProperty]
    public string Serial { get; set; }
    
    private readonly ILogger<DrawModel> _logger;
    
}