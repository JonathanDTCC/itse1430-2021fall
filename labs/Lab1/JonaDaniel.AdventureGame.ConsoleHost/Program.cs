/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;

namespace JonaDaniel.AdventureGame.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayIntroduction();

            bool done = false;

            do
            {
                string command = GetInput();

                switch(command)
                {
                    case "quit": done = HandleQuit(); break;
                    case "help": HelpList(); break;
                    case "look": SearchArea(); break;
                    case "move":
                    case "movenorth": MoveNorth(); break;
                    case "movesouth": MoveSouth(); break;
                    case "moveeast": MoveEast(); break;
                    case "movewest": MoveWest(); break;
                    default: DisplayError("Unknown option"); break;
                };
            } while (!done);
        }
        #region Display Methods
        static void DisplayIntroduction ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ITSE 1430 Adventure Game Fall 2021");
            Console.WriteLine("".PadRight(15, '-'));
            Console.WriteLine("");
            Console.ResetColor();

            //TODO: Make better introduction once an area has been planned and established later
            Console.WriteLine("Why Sentence");
            Console.WriteLine("Where Sentence");
            Console.WriteLine("What next Sentence");

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("What do you want to do?");
            //Console.ResetColor();
        }
        static void HelpList ()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("Move | MoveNorth | MoveSouth | Move East | Move West ::= Move in the indicated direction");
            Console.WriteLine("Look | Search ::= Searches the current area");
            Console.WriteLine("Help ::= Get information about available commands");
            Console.WriteLine("Quit ::= Quit the program");
            Console.ResetColor();
        }
        static void DisplayError ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion

        #region Game Commands
        static void SearchArea()
        {
            //TODO: Later
            Console.WriteLine("You search");
        }
        static void MoveNorth()
        {
            Console.WriteLine("Move North");
        }
        static void MoveSouth ()
        {
            Console.WriteLine("Move South");
        }
        static void MoveEast ()
        {
            Console.WriteLine("Move East");
        }
        static void MoveWest ()
        {
            Console.WriteLine("Move West");
        }

        #endregion

        #region UserInputHandling
        static bool HandleQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? Y/N");
        }
        static bool ReadBoolean ( string message )
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
        static string GetInput()
        {            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.Write("What do you want to do? ");
                Console.ResetColor();

                string input = Console.ReadLine().Trim();

                switch (input.ToUpper())
                {
                    case "MOVE": return "move";
                    case "MOVENORTH": return "movenorth";
                    case "MOVESOUTH": return "movesouth";
                    case "MOVEEAST": return "moveeast";
                    case "MOVEWEST": return "movewest";
                    case "SEARCH": 
                    case "LOOK": return "look";
                    case "HELP": return "help";
                    case "QUIT": return "quit";
                };

                DisplayError("I don't know what that means");
                Console.WriteLine("Type 'help' for a list of commands");
            }
        }
        #endregion
    }
}
