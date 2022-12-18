using CarShowRoom.DbModel;
using CarShowRoom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Controllers;

public class ProductsController : Controller
{
    private readonly CarDbContext _context;

    public ProductsController(CarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult AddCar()
    {
        ViewBag.Manufactures = new SelectList(_context.Manufactures.ToList(), "Id", "Name");
        ViewBag.Colors = _context.Colors.ToList().Select(c => new ColorTip() { Color = c }).ToList();
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AddCar(CarWithSize model)
    {
        if (ModelState.IsValid)
        {
            var car = model.ToDbModel(_context);
            _context.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        ViewBag.Manufactures = new SelectList(_context.Manufactures.ToList(), "Id", "Name");
        return View(model);
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult AddColor()
    {
        return View();
    }
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AddColor(ColorModel color)
    {
        if (ModelState.IsValid)
        {
            _context.Add(color.ToDbModel());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(color);
    }
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult AddManufacture()
    {
        return View();
    }
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AddManufacture(ManufactureModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Add(model.ToDbModel());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(model);
    }
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult AddComplectation()
    {
        ViewBag.Fuel = new SelectList(_context.FuelTypes.ToList(), "Id", "Name");
        ViewBag.Cars =new SelectList(_context.Cars.ToList(), "Id", "ModelName");
        return View();
    }
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AddComplectation(ComplectationModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Add(model.ToDbModel());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Fuel = new SelectList(_context.FuelTypes.ToList(), "Id", "Name");
        ViewBag.Cars =new SelectList(_context.Cars.ToList(), "Id", "ModelName");
        return View(model);
    }
    
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult AddFuelType()
    {
        return View();
    }
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AddFuelType(string fuelName)
    {
        if (ModelState.IsValid)
        {
            _context.Add(new FuelType() {Name = fuelName});
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(fuelName);
    }
    [HttpGet]
    [Authorize(Roles = "admin, user, seller")]
    public IActionResult ShowCar(int carId)
    {
        ViewBag.RoleId = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name)?.RoleId;
        var car = _context.Cars.Include(c => c.Size)
            .Include(c=> c.Colors)
            .Include(c => c.Manufacture)
            .Include(c => c.Complectations)
            .First(c => c.Id == carId);
        return View(car);
    }
    [HttpGet]
    [Authorize(Roles = "admin, user, seller")]
    public IActionResult ShowComplectation(int complectationId)
    {
        var complectation = _context.Complectations.Include(c => c.Car)
            .Include(c => c.FuelType)
            .First(c => c.Id == complectationId);
        return View(complectation);
    }
    [HttpGet]
    [Authorize(Roles = "admin, user, seller")]
    public IActionResult ShowManufacture(int manufactureId)
    {
        var manufacture = _context.Manufactures
            .First(m => m.Id == manufactureId);
        return View(manufacture);
    }
    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult AddSeller()
    {
        return View();
    }
    [HttpPost]
    [Authorize(Roles = "admin")]
    public IActionResult AddSeller(UserModel seller)
    {
        if (ModelState.IsValid)
        {
            _context.Add(seller.ToDbModel());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(seller);
    }
}