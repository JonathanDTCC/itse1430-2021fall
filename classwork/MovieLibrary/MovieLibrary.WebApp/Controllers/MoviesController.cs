using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace MovieLibrary.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController ( IMovieDatabase database )
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

        #region Edit GP
        [HttpGet]
        public IActionResult Edit ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit ( int id, Movie movie )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _database.Update(id, movie);

                    //PRG - post, redirect (to list), get
                    return RedirectToAction(nameof(List));
                };
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(movie);
        }
        #endregion

        #region Create GP
        [HttpGet]
        public IActionResult Create ()
        {
            var movie = new Movie();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Create ( Movie movie )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _database.Add(movie);

                    //PRG - post, redirect (to list), get
                    return RedirectToAction(nameof(List));
                };
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(movie);
        }
        #endregion

        #region Delete GP
        [HttpGet]
        public IActionResult Delete ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete ( int id, Movie movie )
        {
            try
            {
                _database.Delete(id);

                //PRG - post, redirect (to list), get
                return RedirectToAction(nameof(List));
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(movie);
        }
        #endregion

        private readonly IMovieDatabase _database;
    }
}
