using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using DrawService.Interfaces;

namespace DrawService.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : Controller, IDrawService
{
    private readonly ILogger<HomeController> _logger;
    private readonly Random _random = new();
    private readonly IDataProvider _dataProvider;

    public HomeController(ILogger<HomeController> logger, IDataProvider dataProvider)
    {
        _logger = logger;
        _dataProvider = dataProvider;
    }

    [HttpGet("Get")]
    public bool Get()
    {
        return true;
    }

    [HttpPost("SubmitDraw")]
    public Draw? SubmitDraw([FromBody]Draw draw)
    {
        if (_dataProvider.ContainsSerialNumber(draw.Serial.SerialNumber) &&
            _dataProvider.GetDrawCount(draw.Serial.SerialNumber) < 2)
        {
            draw.WinningTicket = _random.Next(0, 2) == 0;
            return _dataProvider.SubmitDraw(draw);
        }
        return null;
    }

    [HttpGet("ListDraws")]
    public IEnumerable<Draw> ListDraws()
    {
        return _dataProvider.ListDraws();
    }
    
    [HttpGet("ValidateSerialNumber/{serial}")]
    public bool ValidateSerialNumber(string serial)
    {
        return _dataProvider.ContainsSerialNumber(serial) && _dataProvider.GetDrawCount(serial) < 2;
    }
    
}