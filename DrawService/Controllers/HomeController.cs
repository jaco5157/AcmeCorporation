using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace DrawService.Controllers;

public class HomeController : Controller, IDrawService
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public bool Get()
    {
        return true;
    }

    public Draw? SubmitDraw(Draw draw)
    {
        Random random = new Random();
        draw.WinningTicket = random.Next(0, 2) == 0;

        _logger.LogInformation(draw.Serial + "Submitted");
        
        return draw;
    }

    public IEnumerable<Draw> ListDraws(string email)
    {
        throw new NotImplementedException();
    }
    
}