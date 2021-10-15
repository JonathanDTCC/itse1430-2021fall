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
                    case "quit" done = HandleQuit(); break;
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
        static void DisplayIntroduction()
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
        static void DisplayError( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static string GetInput()
        {            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();
                string input = Console.ReadLine().Trim();

                switch (input.ToUpper())
                {
                    case "MOVE": return "move";
                    case "MOVENORTH": return "movenorth";
                    case "MOVESOUTH": return "movesouth";
                    case "MOVEEAST": return "moveeast";
                    case "MOVEWEST": return "movewest";
                    case "LOOK": return "look";
                };

                DisplayError("I don't know what that means");
            }
        }
    }
}
