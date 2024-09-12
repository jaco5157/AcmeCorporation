using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary.Interfaces;

namespace Frontend.Controllers;

[IgnoreAntiforgeryToken]
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
    public IActionResult EnterDraw(Draw draw)
    {
        if (!ModelState.IsValid)
        {
            return View(draw);
        }
        if (!_drawService.ValidateSerialNumber(draw.Serial.SerialNumber))
        {
            ModelState.AddModelError("Serial.SerialNumber", "Serial number is invalid or has been used two times already.");
            return View(draw);
        }
        var result = _drawService.SubmitDraw(draw);
        return View("DrawSummary",result);
    }
    
    [HttpGet]
    public IActionResult DrawSummary(Draw draw)
    {
        return View(draw);
    }
}