using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public static class SeedDatabase
    {
        public static void Seed ( this IMovieDatabase database )
        {
            //Collection initializer syntax
            var movies = new[]
            {
                new Movie() {
                    Title = "Jaws",
                    Rating = "PG",
                    RunLength = 210,
                    ReleaseYear = 1979,
                    Description = "Shark movie",
                },
                new Movie() {
                    Title = "Another Movie",
                    Rating = "PG-13",
                    RunLength = 280,
                    ReleaseYear = 2000,
                    Description = "Another movie",
                },
                new Movie() {
                    Title = "Yet Another Movie",
                    Rating = "R",
                    RunLength = 151,
                    ReleaseYear = 2001,
                    Description = "YAN",
                }
            };

            foreach (var movie in movies)
                database.Add(movie);
        }
    }
}
