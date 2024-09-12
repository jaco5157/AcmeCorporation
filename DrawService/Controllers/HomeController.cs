using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace DrawService.Controllers;

public class HomeController : Controller, IDrawService
{
    private readonly ILogger<HomeController> _logger;
    private readonly Random _random = new Random();
    
    private readonly Dictionary<string, int> _serialEntryCounts = new Dictionary<string, int>()
    {
        // Example serial numbers and their entry counts
        { "ABC1234567", 1 },
        { "XYZ9876543", 2 }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public bool Get()
    {
        return true;
    }

    public Draw? SubmitDraw([FromBody]Draw draw)
    {
        draw.WinningTicket = _random.Next(0, 2) == 0;
        return draw;
    }

    public IEnumerable<Draw> ListDraws([FromQuery]string email)
    {
        throw new NotImplementedException();
    }
    
    public bool ValidateSerialNumber([FromQuery]string serial)
    {
        if (!_serialEntryCounts.ContainsKey(serial))
        {
            return false;
        }
        return true;
    }
    
}