using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp2.Models;

namespace tp2.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppdbContext _appdbContext;
        public MovieController(AppdbContext appdbContext)
        {
            _appdbContext = appdbContext;
        }
        public IActionResult Index()
        {
            return View(getAllMovies());
        }

        //a function that handles get request 
        public IActionResult Edit(int id)
        {
            // Retrieve the movie from the database based on the ID
            var movieToEdit = _appdbContext.movies.Find(id);

            // Check if the movie with the given ID exists
            if (movieToEdit == null)
            {
                return Content("Movie Not Found");
            }

            return View(movieToEdit);
        }
        //post request
        [HttpPost]
        public IActionResult Edit(int id, Movie updatedMovie)
        {
            // Find the existing movie based on the provided ID
            var movieToEdit = _appdbContext.movies.Find(id);

            if (movieToEdit == null)
            {
                return Content("Movie Not Found");
            }

            // Update properties of the existing movie with the values from the form
            movieToEdit.Name = updatedMovie.Name; // Assuming your Movie class has a property named Name

            // Validate the model
            if (ModelState.IsValid)
            {
                // Save the changes to the database
                _appdbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the same view with validation errors
            return View(movieToEdit);
        }

        //? means nullable
        public IActionResult Details(int? id)
        {
            if (id == null) return Content("Id Not found");
            var testDetails=getAllMovies().FirstOrDefault(c=>c.Id == id);
            return View(testDetails);
        }
        private IEnumerable<Movie> getAllMovies()
        {
            var movies = _appdbContext.movies.ToList();
            return movies;
        }
        public IActionResult Create()

        {
            return View();
        }

        [HttpPost]
        //prévention contre les attaque XSS
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _appdbContext.movies.Add(movie);
                _appdbContext.SaveChanges();
                return RedirectToAction("Index"); // Redirect to a list of movies or another appropriate action
            }
            return View(movie); // If there are validation errors, return to the same view
        }
        public IActionResult Delete(int id)
        {
            // Retrieve the movie from the database based on the ID
            var movieToDelete = _appdbContext.movies.Find(id);

            // Check if the movie with the given ID exists
            if (movieToDelete == null)
            {
                return Content("Movie Not Found");
            }

            return View(movieToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Movie movie)
        {

            if (movie== null)
            {
                return Content("Movie Not Found");
            }

            // Remove the movie from the context
            _appdbContext.movies.Remove(movie);

            // Save the changes to the database
            _appdbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
