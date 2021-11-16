// ITSE 1430
// Movie Library
// Jonathan Daniel

using System.Collections.Generic;

namespace MovieLibrary
{
    /// <summary>
    /// Represents a movie database.
    /// </summary>
    public interface IMovieDatabase
    {
        // All members are always public, cannot specify access
        // Only type members that are not implementatino details are allowed
        //  Methods, Properties, Events
        // The implementation is not provided

        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        Movie Add ( Movie movie );

        /// <summary>
        /// Deletes a movie
        /// </summary>
        /// <param name="id"></param>
        void Delete ( int id );

        /// <summary>
        /// Gets a movie, if any.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Movie Get ( int id );

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetAll ();

        /// <summary>
        /// Updates a movie in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        void Update ( int id, Movie movie );
    }
}