/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;

namespace JonaDaniel.CharacterCreator.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayIntroduction();
        }
        static void DisplayIntroduction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Jonathan Daniel");
            Console.WriteLine("ITSE 1430 - Fall 2021");
            Console.WriteLine("".PadRight(15, '-'));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ITSE 1430 Character Creator Fall 2021");
            Console.WriteLine("".PadRight(15, '-'));
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
}
