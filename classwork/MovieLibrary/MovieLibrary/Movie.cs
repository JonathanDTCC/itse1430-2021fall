using System;

namespace MovieLibrary
{
    //Naming rules for class
    // 1. Pascal cased
    // 2. Never prefix with T, C or anything else
    // 3. Noun - because they represent an object/entity in your system

    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        //Mixed accessibility - one accessor may be more restrictive
        //public int Id { get; private set; }
        public int Id { get; } //private set ;

        // Properties - methods with field-like syntax, exposes data
        //   Property has a type and name
        //   Properties are Pascal cased and generally public
        //   Property has a getter to read the value and a setter to write the value
        //   Getter must return a value of property type
        //   Setter has a single parameter called `value` of property type
        public string Title
        {
            //Read: T get_Title ()
            get {
                return (_title != null) ? _title : "";
                //if (_title == null)
                //    return "";

                //return _title; 
            }

            //Write void set_Title ( string value ) 
            set {
                //_title = value;
                _title = (value != null) ? value.Trim() : null;
            }
        }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return (_description != null) ? _description : ""; }
            set { _description = (value != null) ? value.Trim() : null; }
        }

        public string Rating
        {
            get { return (_rating != null) ? _rating : ""; }
            set { _rating = (value != null) ? value.Trim() : null; }
        }

        //Full property syntax
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //Auto property
        public int RunLength { get; set; }

        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        /// <summary>Gets or sets the release year.</summary>
        /// <value>MinimumReleaseYear</value>
        public int ReleaseYear { get; set; } = MinimumReleaseYear;

        //public double ReviewRating
        //{
        //    get { return _reviewRating; }
        //    set { _reviewRating = value; }
        //}
        public double ReviewRating { get; set; }

        public bool IsClassic { get; set; }
        //{
        //    get { return _isClassic; }
        //    set { _isClassic = value; }
        //}

        //TODO: Fix field casing, don't make public
        // Fields
        //  1. Always camel cased
        //  2. Should NEVER be public
        //  3. Always zero initialized or can default
        //  4. Cannot initialize to another field's value
        private string _title;
        private string _description;
        //private int _runLength;

        //TODO: Use the const Luke
        //private int _releaseYear = MinimumReleaseYear;

        //private double _reviewRating;
        private string _rating;
        //private bool _isClassic;

        // Field is constant and therefore cannot be changed without recompiling
        public const int MinimumReleaseYear = 1900;

        //public int GetAgeInYears ()
        //{
        //    return DateTime.Now.Year - ReleaseYear;
        //}
        public int AgeInYears
        {
            get { return DateTime.Now.Year - ReleaseYear; }
            //set { }
        }

        //public bool IsBlackAndWhite ()
        //{
        //    return ReleaseYear < 1922;
        //}
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < 1922; }
        }

        // Methods - provide functionality (function inside a class)
        //   Can reference fields in method
        //   `this` represents the current instance, always the first parameter (implied)

        /// <summary>Copies the movie.</summary>
        /// <returns>A copy of the movie.</returns>
        public Movie Copy ()
        {
            var movie = new Movie();
            movie.Title = Title;
            movie.Description = Description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.ReviewRating = ReviewRating;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;

            return movie;
        }

        /// <summary>Validates the object.</summary>
        /// <returns>The error, if any.</returns>
        public string Validate ( /* Movie this */ )
        {
            //Title is required
            if (String.IsNullOrEmpty(Title)) // this.title            
                return "Title is required";

            //Run length >= 0
            //if (this.runLength < 0)
            if (RunLength < 0)
                return "Run Length must be at least zero";

            //Release year >= 1900            
            if (ReleaseYear < MinimumReleaseYear)
                return "Release Year must be at least " + MinimumReleaseYear;

            return null;
        }

        private void SetDescriptionToTitle ()
        {
            Description = Title;
        }
    }
}
