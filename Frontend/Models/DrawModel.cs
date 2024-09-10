using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Classes;

namespace Frontend.Models;

public class DrawModel
{
    public Person Person { get; set; }
    public string Serial { get; set; }
    
    private readonly ILogger<DrawModel> _logger;
    
}