using System.Diagnostics;
using ClassLibrary.Classes;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Interfaces;

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

    public Draw? DrawEntry(Draw draw)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Draw> ListEntries(string email)
    {
        throw new NotImplementedException();
    }
    
}