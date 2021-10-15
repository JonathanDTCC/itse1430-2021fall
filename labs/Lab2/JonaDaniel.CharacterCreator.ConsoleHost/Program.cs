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

            do
            {
                char choice = GetInput();

                switch (choice)
                {
                    case 'C': CreateCharacter(); break;
                    case 'V': ViewCharacter(); break;
                    case 'E': EditCharacter(); break;
                    case 'D': DeleteCharacter(); break;
                    default: DisplayError("Unknown option"); break;
                };
            } while (true);
        }
        #region Character Methods
        static void CreateCharacter()
        {
            Console.WriteLine("Create Character");
            //TODO: Creation Later Story
        }

        static void ViewCharacter()
        {
            Console.WriteLine("View Character");
            //TODO: View Character
        }

        static void EditCharacter()
        {
            Console.WriteLine("Edit Character");
            //TODO: Edit Character
            //TODO: Confirmation
            //CreateCharacter();
        }
        
        static void DeleteCharacter()
        {
            Console.WriteLine("Delete Character");
            //TODO: Delete character
            //TODO: Confirmation
        }
        #endregion
        #region Input Methods
        static char GetInput()
        {
            while (true)
            {
                DisplayMenu();
                string input = Console.ReadLine().Trim();

                switch(input.ToUpper())
                {
                    case "C": return 'C';
                    case "V": return 'V';
                    case "E": return 'E';
                    case "D": return 'D';
                };

                DisplayError("Invalid Input");
            }
        }
        #endregion
        #region Display Methods
        static void DisplayIntroduction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Jonathan Daniel");
            Console.WriteLine("ITSE 1430 - Fall 2021");
            Console.WriteLine("".PadRight(15, '-'));

            DisplayMenu();
        }
        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ITSE 1430 Character Creator Fall 2021");
            Console.WriteLine("".PadRight(15, '-'));
            Console.WriteLine("");
            Console.ResetColor();

            Console.WriteLine("C)reate Character");
            Console.WriteLine("V)iew Character");
            Console.WriteLine("E)dit Character");
            Console.WriteLine("D)elete Character");
        }

        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        #endregion
    }
}
