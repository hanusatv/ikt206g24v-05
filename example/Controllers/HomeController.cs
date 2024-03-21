using System.Diagnostics;
using Example.Data;
using Microsoft.AspNetCore.Mvc;
using Example.Models;

namespace Example.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    // Added application db context as parameter
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
