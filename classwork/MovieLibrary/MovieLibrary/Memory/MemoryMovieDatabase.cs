// ITSE 1430
// Movie Library
// Jonathan Daniel

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase : IMovieDatabase
    {
        public MemoryMovieDatabase ()
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
                    Id = 1,
                },
                new Movie() {
                    Title = "Another Movie",
                    Rating = "PG-13",
                    RunLength = 280,
                    ReleaseYear = 2000,
                    Description = "Another movie",
                    Id = 2,
                },
                new Movie() {
                    Title = "Yet Another Movie",
                    Rating = "R",
                    RunLength = 151,
                    ReleaseYear = 2001,
                    Description = "YAN",
                    Id = 3,
                }
            };

            _items.AddRange(movies);
            //Object initializer - creating and initializing new object
            // new T() {
            //      Property 1 = Value1,
            //      Property 2 = Value2,
            //      ...
            // };
            //_items.Add(new Movie() {
            //    Title = "Jaws",
            //    Rating = "PG",
            //    RunLength = 210,
            //    ReleaseYear = 1979,
            //    Description = "Shark movie",
            //    Id = 1,
            //});

            //_items.Add(new Movie() {
            //    Title = "Another Movie",
            //    Rating = "PG-13",
            //    RunLength = 280,
            //    ReleaseYear = 2000,
            //    Description = "Another movie",
            //    Id = 2,
            //});

            //_items.Add(new Movie() {
            //    Title = "Yet Another Movie",
            //    Rating = "R",
            //    RunLength = 151,
            //    ReleaseYear = 2001,
            //    Description = "YAN",
            //    Id = 3,
            //});
        }

        public void IsOnlyAvailableInMemoryMovieDatabase () 
        { }

        //TODO: Error Handling
        public Movie Add ( Movie movie, out string error )
        {
            //Movie must be valid
            var validator = new ObjectValidator();
            if(!validator.TryValidate(movie, out error))
                return null;

            //error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return null;

            //Movie title must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                error = $"{movie.Title} already exists";
                return null;
            };

            //Clone
            var newMovie = movie.Clone();

            //set unique ID
            newMovie.Id = _nextId++;

            _items.Add(newMovie);

            movie.Id = newMovie.Id;
            return movie;
        }

        private Movie FindByTitle ( string title )
        {
            foreach (var movie in _items)
                if (String.Compare(title, movie.Title, true) == 0)
                    return movie;

            return null;
        }

        //Update
        public string Update ( int id, Movie movie )
        {
            //Movie must be valid
            var validator = new ObjectValidator();
            if (!validator.TryValidate(movie, out var error))
                return error;

            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            //Movie must exist
            var existing = FindById(id);
            if (existing == null)
                return "Movie not found";

            //Movie title must be unique
            var dup = FindByTitle(movie.Title);
            if (dup != null && dup.Id != id)
                return "Movie must be unique";

            Copy(existing, movie);
            return null;
        }

        private void Copy ( Movie target, Movie source )
        {
            target.Title = source.Title;
            target.Description = source.Description;
            target.Rating = source.Rating;
            target.RunLength = source.RunLength;
            target.ReleaseYear = source.ReleaseYear;
            target.IsClassic = source.IsClassic;
        }

        //Delete
        public void Delete ( int id )
        {
            //TODO: Validate id
            var movie = FindById(id);
            if (movie != null)
                _items.Remove(movie);
        }

        private Movie FindById ( int id )
        {
            foreach (var movie in _items)
                if (id == movie.Id)
                    return movie;

            return null;
        }

        //Get
        public Movie Get ( int id )
        {
            //TODO: Validate id
            var movie = FindById(id);

            return movie?.Clone();
        }
        //Get All
        public IEnumerable<Movie> GetAll ()
        {
            //NEVER DO THIS - should not return a ref type directly, it can be modified
            //return _items;

            int counter = 0;

            //Use iterator syntax
            foreach (var item in _items)
            {
                ++counter;
                yield return item.Clone();
            };

            ////Must clone both array and movies to return new copies
            ////Each iteration the next element is copied to the item variable
            //var items = new Movie[_items.Count];

            //var index = 0;
            //foreach (var item in _items)
            //    items[index++] = item.Clone();

            //return items;
        }

        //Dynamically resizing array
        private List<Movie> _items = new List<Movie>();
        private int _nextId = 1;

    }
}
