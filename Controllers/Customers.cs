using EFCoreFirst.Models;
using Microsoft.AspNetCore.Mvc;

public class CustomersController : Controller
{
    private readonly CarDealerContext _context;

    public CustomersController(CarDealerContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    public IActionResult Index()
    {
        var customers = _context.Customer.ToList();
        return View(customers);
    }
}
