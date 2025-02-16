using Microsoft.AspNetCore.Mvc;
using Mission6KW.Models;

namespace Mission6KW.Controllers;

// HomeController handles requests related to the main pages and movie entry
public class HomeController : Controller
{
    private MovieDbContext _context; // Database context to interact with the Movie database

    // Constructor that injects the database context
    public HomeController(MovieDbContext temp)
    {
        _context = temp;
    }

    // Action method for the home page (Index view)
    public IActionResult Index()
    {
        return View();
    }

    // Action method for the "Get To Know Joel" page
    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    // Displays the form for entering a new movie (GET request)
    [HttpGet]
    public IActionResult EnterMovie()
    {
        return View();
    }

    // Handles form submission for entering a new movie (POST request)
    [HttpPost]
    public IActionResult EnterMovie(Movie movie)
    {
        // Check if the submitted model is valid
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie); // Adds the movie to the database
            _context.SaveChanges(); // Saves changes to the database
            ViewBag.SuccessMessage = "Movie added successfully!"; // Displays success message
        }

        return View(); // Reloads the EnterMovie view
    }
}