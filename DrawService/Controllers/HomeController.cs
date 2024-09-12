using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace DrawService.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : Controller, IDrawService
{
    private readonly ILogger<HomeController> _logger;
    private readonly Random _random = new();
    
    private readonly Dictionary<string, int> _serialEntryCounts = new()
    {
        // Example serial numbers and their entry counts
        { "ABC1234567", 1 },
        { "XYZ9876543", 2 }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Get")]
    public bool Get()
    {
        return true;
    }

    [HttpPost("SubmitDraw")]
    public Draw? SubmitDraw([FromBody]Draw draw)
    {
        draw.WinningTicket = _random.Next(0, 2) == 0;
        return draw;
    }

    [HttpGet("ListDraws")]
    public IEnumerable<Draw> ListDraws()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("ValidateSerialNumber/{serial}")]
    public bool ValidateSerialNumber(string serial)
    {
        return _serialEntryCounts.ContainsKey(serial);
    }
    
}