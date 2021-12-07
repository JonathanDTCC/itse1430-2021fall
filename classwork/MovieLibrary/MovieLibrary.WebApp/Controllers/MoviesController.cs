using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace MovieLibrary.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController( IMovieDatabase database )
        {
            _database = database;
        }

        public IActionResult List ()
        {
            var movies = _database.GetAll()
                                    .OrderBy(x => x.Title);

            return View(movies);
            //return Json(new Movie() {
            //    Title = "Jaws",
            //    Description = "Shark movie",
            //    ReleaseYear = 1978,
            //    RunLength = 210,
            //});
        }

        private readonly IMovieDatabase _database;
    }
}
