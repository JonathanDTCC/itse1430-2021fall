// ITSE 1430
// Movie Library
// Jonathan Daniel

namespace MovieLibrary
{
    public interface IMovieDatabase
    {
        // All members are always public, cannot specify access
        // Only type members that are not implementatino details are allowed
        //  Methods, Properties, Events
        // The implementation is not provided
        Movie Add ( Movie movie, out string error );
        void Delete ( int id );
        Movie Get ( int id );
        Movie[] GetAll ();
        string Update ( int id, Movie movie );
    }
}