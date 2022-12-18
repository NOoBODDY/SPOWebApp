using System.Diagnostics;
using CarShowRoom.DbModel;
using Microsoft.AspNetCore.Mvc;
using CarShowRoom.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarShowRoom.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CarDbContext _context;

    public HomeController(ILogger<HomeController> logger, CarDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        ViewBag.Cars = _context.Cars.ToList();
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