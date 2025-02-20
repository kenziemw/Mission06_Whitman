using Microsoft.AspNetCore.Mvc;
using Mission6KW.Models;
using System.Diagnostics;

namespace Mission6KW.Controllers
{
    public class HomeController : Controller
    {
        // Dependency injection for database context
        private readonly MovieDbContext _context;

        public HomeController(MovieDbContext context)
        {
            _context = context;
        }

        // ✅ GET method: Display the "Get to Know Joel" page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // ✅ GET method: Display the home page
        public IActionResult Index()
        {
            return View();
        }

        // ✅ GET method: Display the form to add a new movie
        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View(); // 🔹 Ensure it returns the EnterMovie.cshtml view
        }
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound(); // 🔹 Return 404 if the movie is not found
            }

            return View("EnterMovie", movie); // 🔹 Load the same form for editing
        }


        // ✅ POST method: Handles adding or updating a movie
        [HttpPost]
        [ValidateAntiForgeryToken] // 🔹 Security best practice to prevent CSRF attacks
        public IActionResult SaveMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View("EnterMovie", movie); // Return to form if validation fails
            }

            if (movie.MovieId == 0)  // If MovieId is 0, it's a new movie
            {
                _context.Movies.Add(movie);
            }
            else
            {
                _context.Movies.Update(movie); // Otherwise, update existing movie
            }

            _context.SaveChanges(); // Commit changes to the database
            return RedirectToAction("MovieList"); // Redirect to the movie list after saving
        }

        // ✅ GET method: Display the list of movies
        public IActionResult MovieList()
        {
            var movies = _context.Movies.ToList();
            return View(movies); // ✅ Corrected: Pass list of movies directly
        }

        // ✅ POST method: Delete a movie by ID
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound(); // Return 404 if movie is not found
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges(); // Commit deletion to the database
            return RedirectToAction("MovieList"); // Redirect to the movie list after deletion
        }
    }
}
