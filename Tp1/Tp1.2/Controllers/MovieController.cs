using Microsoft.AspNetCore.Mvc;
using Tp1._2.Models;

namespace Tp1._2.Controllers
{
    [Route("/Movie")]
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            Movie movie = new Movie()
            {
                Name =
            "movie 1"
            };
            List<Movie> movies = new List<Movie>()
            {
                new Movie{Name="movie 2"},
                new Movie{Name="movie 3"},
            };
            return View(movies);
        }
        [HttpGet("released/{year}/{month}")]
        public IActionResult released(int year, int month)
        {
            return Content("mn aam " + year + " chhar " + month);
        }

    }
}
