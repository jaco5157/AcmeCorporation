using System.Diagnostics;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;

namespace Frontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDrawService _drawService;

    public HomeController(ILogger<HomeController> logger, IDrawService drawService)
    {
        _logger = logger;
        _drawService = drawService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult EnterDraw()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EnterDraw(Person person, string serial)
    {
        _logger.LogInformation(person.FirstName + " entered draw");
        _drawService.SubmitDraw(new Draw(serial, person));
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}