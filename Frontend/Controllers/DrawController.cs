using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Interfaces;

namespace Frontend.Controllers;

public class DrawController : Controller
{
    private readonly ILogger<DrawController> _logger;
    private readonly IDrawService _drawService;

    public DrawController(ILogger<DrawController> logger, IDrawService drawService)
    {
        _logger = logger;
        _drawService = drawService;
    }
    
    public IActionResult EnterDraw()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EnterDraw(Draw draw)
    {
        _logger.LogInformation(draw.Person.FirstName + " entered draw");
        _drawService.SubmitDraw(draw);
        return View();
    }
}