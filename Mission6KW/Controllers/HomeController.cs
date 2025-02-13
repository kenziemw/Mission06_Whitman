using Microsoft.AspNetCore.Mvc;
using Mission6KW.Models;

namespace Mission6KW.Controllers;

public class HomeController : Controller
{
    private MovieDbContext _context;

    public HomeController(MovieDbContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EnterMovie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult EnterMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            ViewBag.SuccessMessage = "Movie added successfully!";
        }

        return View();
    }
}