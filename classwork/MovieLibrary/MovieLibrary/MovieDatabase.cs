// ITSE 1430
// Movie Library
// Jonathan Daniel

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieDatabase
    {
        public MovieDatabase ()
        {
            //TODO: Seed
            //Object initializer - creating and initializing new object
            // new T() {
            //      Property 1 = Value1,
            //      Property 2 = Value2,
            //      ...
            // };
            _items[0] = new Movie() {
                Title = "Jaws",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1979,
                Description = "Shark movie",
                Id = 1,
            };

            _items[1] = new Movie() {
                Title = "Another Movie",
                Rating = "PG-13",
                RunLength = 280,
                ReleaseYear = 2000,
                Description = "Another movie",
                Id = 2,
            };

            _items[2] = new Movie() {
                Title = "Yet Another Movie",
                Rating = "R",
                RunLength = 151,
                ReleaseYear = 2001,
                Description = "YAN",
                Id = 3,
            };
        }

        //TODO: Add
        public void Add ( Movie movie )
        {

        }

        //TODO: Update
        public void Update ( Movie movie )
        {
        }
        //TODO: Delete
        public void Delete ( Movie movie )
        {
        }
        //TODO: Get
        public Movie Get ()
        {
            return null;
        }
        //TODO: Get All
        public Movie[] GetAll ()
        {
            //NEVER DO THIS
            //return _items;
            //Array.Copy() - will copy array but not ref movies

            //Need to filter out null movies
            var count = 0;
            foreach (var item in _items)
            {
                if (item != null)
                    ++count;
            };

            //Must clone both array and movies to return new copies
            //Each iteration the next element is copied to the item variable
            var items = new Movie[count];

            //Don't need the for loop
            //for(int index = 0; index < _items.Length; ++index)
            //{ items[index] = Copy(_items[index]);  };

            //Each iteration the next element is copied to the item variable
            // 3 limitations
            //   No index (use a simple index variable)
            //   Item is readonly
            //   Array cannot change for the life of the loop (keep a seperate list)
            var index = 0;
            foreach (var item in _items)
            {
                if (item != null)
                    items[index++] = item.Clone();
            };

            return items;
        }

        //Arrays are always open in C#
        //Arrays size is specified at the point of creation
        private Movie[] _items = new Movie[100];

    }
}
