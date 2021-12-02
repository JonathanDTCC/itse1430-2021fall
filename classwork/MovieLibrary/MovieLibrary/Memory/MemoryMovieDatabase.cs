// ITSE 1430
// Movie Library
// Jonathan Daniel

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase : IMovieDatabase
    {
        //Not visible to code that uses the interface
        public void IsOnlyAvailableInMemoryMovieDatabase ()
        { }

        //TODO: Error Handling
        public Movie Add ( Movie movie )
        {
            //Validation
            // Movie is not null
            // Movie is valid
            // Movie cannot already exist
            //if (movie == null)
            // throw new ArgumentNullException(nameof(movie));
            var item = movie ?? throw new ArgumentNullException(nameof(movie));

            //Movie must be valid
            ObjectValidator.Validate(movie);

            //Movie title must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                throw new InvalidOperationException("Movie must be unique");


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
            return _items.FirstOrDefault(movie => String.Compare(title, movie.Title, true) == 0);

            //foreach (var movie in _items)
            //    if (String.Compare(title, movie.Title, true) == 0)
            //        return movie;

            //return null;
        }

        //Update
        public void Update ( int id, Movie movie )
        {
            //Validation
            // Id must be > 0
            // Movie is not null
            // Movie is vaid
            // Movie does not already exist
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            //Movie must be valid
            ObjectValidator.Validate(movie);

            //Movie must exist
            var existing = FindById(id);
            if (existing == null)
                throw new Exception("Movie not found");

            //Movie title must be unique
            var dup = FindByTitle(movie.Title);
            if (dup != null && dup.Id != id)
                throw new InvalidOperationException("Movie must be unique");

            Copy(existing, movie);
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
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            //TODO: Validate id
            var movie = FindById(id);
            if (movie != null)
                _items.Remove(movie);
        }

        [Conditional("DEBUG")]
        private void Dump ()
        {
        }

        [Obsolete("Use GetCore instead")]
        private Movie FindById ( int id )
        {
            //Where (Func<Movie, bool>) -> IEnumerable<T>
            //return _items.Where(x => x.Id = id)
            //             .FirstOrDefault();

            //LINQ extension method
            //return _items.FirstOrDefault(movie => movie.Id == id);

            //LINQ syntax
            return (from movie in _items
                    where movie.Id == id
                    select movie).FirstOrDefault();

            //foreach (var movie in _items)
            //    if (id == movie.Id)
            //        return movie;

            //return null;
        }

        //Get
        public Movie Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            //TODO: Validate id
            var movie = FindById(id);

            return movie?.Clone();
        }

        private class IdAndTitle
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
        private IdAndTitle Convert ( Movie movie )
        {
            return new IdAndTitle() {
                Id = movie.Id,
                Title = movie.Title
            };
        }
        //Get All
        public IEnumerable<Movie> GetAll ()
        {
            //NEVER DO THIS - should not return a ref type directly, it can be modified
            //return _items;

            //int counter = 0;

            //Use iterator syntax
            IEnumerable<Movie> items = _items;

            //Select transforms S to T
            //IEnumerable<IdAndTitle> titles = _items.Selec<Movie, IdAndTitle>(Convert);
            //IEnumerable<IdAndTitle> titles = _items.Select(Convert);
            //return _items.Select(Clone);

            //Using LINQ extension method here
            //return _items.Select(x => x.Clone());

            //LINQ syntax equivalent
            return from x in _items
                   select x.Clone();

            //foreach (var item in _items)
            //{
            //    yield return item.Clone();
            //};

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
