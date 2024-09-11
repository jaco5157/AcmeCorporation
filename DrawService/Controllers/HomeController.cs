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
        _logger.LogInformation(draw.Serial + "Submitted");
        return draw;
        //throw new NotImplementedException();
    }

    public IEnumerable<Draw> ListDraws(string email)
    {
        throw new NotImplementedException();
    }
    
}