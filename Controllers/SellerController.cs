using CarShowRoom.DbModel;
using CarShowRoom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Controllers;

public class SellerController : Controller
{
    private readonly CarDbContext _context;

    public SellerController(CarDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Authorize(Roles = "admin, seller")]
    public IActionResult Index()
    {
        ViewBag.Contracts = _context.Contracts.ToList();
        ViewBag.Orders = _context.Orders.ToList();
        return View();
    }
    
    [HttpGet]
    [Authorize(Roles = "seller")]
    public IActionResult CreateContract(int carId)
    {
        ViewBag.SellerId = _context.Users.FirstOrDefault(x => x.Login == User.Identity.Name)?.Id;
        var car = _context.Cars.Include(c=> c.Complectations).FirstOrDefault(x => x.Id == carId);
        if (car == null)
            throw new Exception("No such car");
        ViewBag.CarModel = car.ModelName;
        ViewBag.CarId = carId;
        ViewBag.Complectations = new SelectList(car.Complectations, "Id", "Name");
        return View();
    }
    [HttpPost]
    [Authorize(Roles = "seller")]
    public IActionResult CreateContract(ContractModel model)
    {
        if (ModelState.IsValid)
        {
            Contract contract = model.ToDbModel();
            _context.Add(contract);
            _context.SaveChanges();
            return RedirectToAction("ShowContract", "Seller", contract.Id);
        }
        return View(model);
    }
    
    [HttpGet]
    [Authorize(Roles = "seller")]
    public IActionResult OrderTheModel(int contractId)
    {
        var contract = _context.Contracts.Include(c=> c.Complectation).First(c => c.Id == contractId);
        var order = new Order()
        {
            ContractId = contractId,
            DeliveryDate = DateTime.Today + TimeSpan.FromDays(contract.Complectation.DeliveryTime)
        };
        _context.Add(order);
        _context.SaveChanges();
        return RedirectToAction("ShowContract", "Seller", contractId);
    }
    
    [HttpGet]
    [Authorize(Roles = "admin, seller")]
    public IActionResult ShowContract(int contractId)
    {
        var contract = _context.Contracts
            .Include(c=> c.Seller)
            .Include(c => c.Complectation).ThenInclude(c => c.Car)
            .First(c => c.Id == contractId);
        return View(contract);
    }
    
}