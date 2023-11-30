using Microsoft.AspNetCore.Mvc;
using tp2.Models;

namespace tp2.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppdbContext _db;
        public GenreController(AppdbContext db)
        {
            _db = db;
        }
    }
}
