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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What do you want to do?");
            Console.ResetColor();
        }
    }
}
