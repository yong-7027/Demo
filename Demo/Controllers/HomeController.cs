using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers;

public class HomeController : Controller
{
    private readonly DB db;
	public HomeController(DB db)
    {
        this.db = db;
	}

    // GET: Home/Index
    public IActionResult Index()
    {
        var m = db.Students.Include(s => s.Program);

        return View(m);
    }

    // GET: Home/Detail
    public IActionResult Detail(string? id)
    {
        var m = db.Students.Include(s => s.Program).FirstOrDefault(s => s.Id == id);
        if (m == null)
        {
            return RedirectToAction("Index");
        }

        return View(m);
    }
}
