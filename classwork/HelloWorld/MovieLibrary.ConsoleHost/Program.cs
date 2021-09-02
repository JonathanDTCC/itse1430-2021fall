using System;

namespace MovieLibrary.ConsoleHost
{
    class Program
    {
        static void Main ( string[] args )
        {
            bool done = false;

            char choice = GetInput();
            if (choice == 'Q')
                done = HandleQuit();
            else if (choice == 'A')
                AddMovie();
            else
                Console.WriteLine("Unknown option");
            //TODO: handle additional stuff


        }

        static void AddMovie ()
        {
            //Movie details
            string title = ReadString("Enter the movie title: ", true);    
            string description = ReadString("Enter the optional description: ", false);

            int runLength = ReadInt32("Enter run length (in minutes): ", 0);         //>=0
            int releaseYear = ReadInt32("Enter the release year (min 1900): ", 1900);       //1900+

            double reviewRating;   //Optional, 0.0 to 5.0
            string rating = ReadString("Enter the MPAA rating: ", false);
            bool isClassic;        //Optional
        }

        private static int ReadInt32 ( string message, int minimumValue ) 
        {
            Console.Write(message);

            string input = Console.ReadLine();

            //TODO: Input validation
            //int result = Int32.Parse(input); //Crashes program, not good for input
            int result;
            if(Int32.TryParse(input, out result))
                return result;

            return -1;
        }

        private static string ReadString ( string message, bool required )
        {
            Console.Write(message);

            //TODO: Input validation - required, normalize
            string input = Console.ReadLine();

            return input;
        }

        private static bool HandleQuit ()
        {
            //return ReadBoolean("Are you sure you want to quit (Y/N)?");

            //Display a confirmation
            if (ReadBoolean("Are you sure you want to quit (Y/N)?"))
                return true;

            return false;
        }

        private static bool ReadBoolean ( string message )
        {
            Console.Write(message);

            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Y)
                return true;

            //TODO: Input validation
            return false;
        }

        static char GetInput ()
        {
            Console.WriteLine("Movie Library");
            Console.WriteLine("----------------");

            Console.WriteLine("A) dd");
            Console.WriteLine("Q)uit");
            
            //TODO: Input validation
            //Get input
            string input = Console.ReadLine();
            if (input == "Q")
                return 'Q';
            else if (input == "A")
                return 'A';

            return default(char); //default
        }
    }
}