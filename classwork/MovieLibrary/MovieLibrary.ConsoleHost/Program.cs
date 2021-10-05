// ITSE 1430
// Movie Library
using System;

namespace MovieLibrary.ConsoleHost
{
    //Main program
    class Program
    {
        //Entry point function
        static void Main ( string[] args )
        {
            bool done = false;

            do
            {
                char choice = GetInput();
                switch (choice)
                {
                    case 'Q':
                    {
                        done = HandleQuit();
                        break;
                    };
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;
                    case 'D': DeleteMovie(); break;
                    default: DisplayError("Unknown option"); break;
                };
            } while (!done);
        }

        //Using null to represent no movie yet
        static Movie movie; // = new Movie();

        /// <summary>Deletes the movie, if any.</summary>
        private static void DeleteMovie ()
        {
            if (movie == null)
                return;

            //var newMovie = movie.Copy();

            //Confirm
            if (!ReadBoolean("Are you sure (Y/N)? "))
                return;

            //TODO: Delete movie
            movie = null;
        }

        /// <summary>Adds a movie.</summary>
        static void AddMovie ()
        {
            //Store in a temp variable until validated
            //var newMovie = new Movie();
            var newMovie = new Movie(10, "temp");
            //newMovie.Id = 10;
            //newMovie.Title = "temp";

            do
            {
                // newMovie.set_Title(...)
                newMovie.Title = ReadString("Enter the movie title: ", false);
                newMovie.Description = ReadString("Enter the optional description: ", false);

                newMovie.RunLength = ReadInt32("Enter run length (in minutes): ", 0); // >= 0
                newMovie.ReleaseYear = ReadInt32("Enter the release year (min 1900): ", Movie.MinimumReleaseYear); //1900+

                //double reviewRating;  //Optional, 0.0 to 5.0
                newMovie.Rating = ReadString("Enter the MPAA rating: ", false); //MPAA (not enforced)
                newMovie.IsClassic = ReadBoolean("Is this a classic (Y/N)? ");       //Optional

                //Validate
                var error = newMovie.Validate();
                if (String.IsNullOrEmpty(error))
                {
                    //TODO: Save movie
                    movie = newMovie;
                    return;
                };

                DisplayError(error);
            } while (true);
        }

        /// <summary>Displays the entered movie.</summary>
        static void ViewMovie ()
        {
            //What if they haven't added one yet?
            //if (String.IsNullOrEmpty(movie.title))
            if (movie == null)
            {
                Console.WriteLine("No movie available");
                return;
            };

            //movie.get_Title()
            Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})");
            Console.WriteLine($"Runtime: {movie.RunLength} mins");
            Console.WriteLine($"MPAA Rating {movie.Rating}");
            Console.WriteLine($"Classic? {movie.IsClassic}");
            Console.WriteLine(movie.Description);

            if (movie.AgeInYears >= 25)
                Console.WriteLine($"{movie.AgeInYears}th Anniversary");
            //movie.AgeInYears = 10;
        }

        /// <summary>Handles quit logic.</summary>
        /// <returns>true to quit the program.</returns>
        private static bool HandleQuit ()
        {
            //Display a confirmation
            if (ReadBoolean("Are you sure you want to quit (Y/N)? "))
                return true;

            return false;
        }

        /// <summary>Reads a boolean value as Y/N.</summary>
        /// <param name="message">The message to show.</param>
        /// <returns>The user input.</returns>
        private static bool ReadBoolean ( string message )
        {
            Console.Write(message);

            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y)
                    return true;
                else if (input.Key == ConsoleKey.N)
                    return false;
            } while (true);
        }

        /// <summary>Reads an Int32 from the console.</summary>
        /// <param name="message">The message to display.</param>
        /// <param name="minimumValue">The minimum value allowed.</param>
        /// <returns>The integrval value that was entered.</returns>
        static int ReadInt32 ( string message, int minimumValue )
        {
            Console.Write(message);

            //Validate input
            do
            {
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result) && result >= minimumValue)
                    return result;

                DisplayError("The value must be an integral value >= " + minimumValue);
            } while (true);
        }

        /// <summary>Reads a string from the console.</summary>
        /// <param name="message">The message to show.</param>
        /// <param name="required">true if the value is required.</param>
        /// <returns>The user input.</returns>
        static string ReadString ( string message, bool required )
        {
            Console.Write(message);

            do
            {
                string input = Console.ReadLine().Trim();

                //Is required
                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                DisplayError("Value is required");
            } while (true);
        }

        /// <summary>Displays an error message.</summary>
        /// <param name="message">The message to show.</param>
        static void DisplayError ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>Gets user input for menu.</summary>
        /// <returns>The selected option.</returns>
        static char GetInput ()
        {
            Console.WriteLine("Movie Library");
            Console.WriteLine("".PadLeft(15, '-'));

            Console.WriteLine("A) dd");
            Console.WriteLine("V) iew");
            Console.WriteLine("D) elete");
            Console.WriteLine("Q) uit");

            while (true)
            {
                //Get input 
                string input = Console.ReadLine().Trim();
                switch (input.ToUpper())
                {
                    case "C": return 'B';
                    case "Q": return 'Q';
                    case "A": return 'A';
                    case "V": return 'V';
                    case "D": return 'D';
                };

                DisplayError("Invalid input");
            };
        }
        static void DemoObjects ()
        {
            object someValue = 10;
            someValue = "Hello";

            Print(10);
            Print("Hello");
            Print(45.6);
            //someValue.Equals(10);
        }
        static void Print ( object value )
        {
            //Console.WriteLine(value);

            //Type checking
            // is-operator ::= E is T (returns bool)
            // as-operator ::= E as T (returns T or null), does not work with primitives
            // pattern-matching ::= E is T id = (returns E as T if valid or false otherwise)

            //Type casting
            // c-style ::= (T) E blows up at runtime if wrong, only use with primitives

            if (value is int)
            {
                Console.WriteLine((int)value);
                return;
            };

            string str = value as string;
            if(str != null)
            {
                Console.WriteLine(str);
                return;
            };

            //Best choice
            if (value is double doubleValue)
            {
                Console.WriteLine(doubleValue);
                return;
            };

            //int x;

            //if (x == null)

            //Value types follow value assignment (copy)
            int x = 10;
            int y = x;
            x = 20;
            Console.WriteLine(y); //10

            //Value types follow value semantics
            var equal = x == y;

            //Reference types follow reference assignment
            Movie m1 = new Movie();
            Movie m2 = m1;
            m1.Title = "Jaws";
            Console.WriteLine(m2.Title); //Jaws

            //Ref types follow reference semantics
            equal = m1 == m2;  //Object.Equals
        }
    }
}