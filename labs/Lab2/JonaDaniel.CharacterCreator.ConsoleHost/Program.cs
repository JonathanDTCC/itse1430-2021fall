/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;

namespace JonaDaniel.CharacterCreator.ConsoleHost
{
    class Program
    {
        static void Main ( string[] args )
        {
            DisplayIntroduction();

            bool done = false;

            do
            {
                char choice = GetInput();

                switch (choice)
                {
                    case 'C': CreateCharacter(); break;
                    case 'V': ViewCharacter(); break;
                    case 'E': EditCharacter(); break;
                    case 'D': DeleteCharacter(); break;
                    case 'Q': done = ConfirmQuit(); break;
                    default: DisplayError("Unknown option"); break;
                };
            } while (!done);
        }

        static Character character;
        #region Character Methods
        static void CreateCharacter ()
        {
            var newCharacter = new Character("temp", "unset", "unset");

            do
            {
                newCharacter.Name = ReadString("Enter your characters name: ", true);

                newCharacter.Profession = ChooseFromList("Profession", Character.ValidProfessions, true, true);
                newCharacter.Race = ChooseFromList("Race", Character.ValidRaces, true, true);

                newCharacter.Biography = ReadString("Enter an optional biography for your character", false);

                newCharacter.Strength = ReadInt32($"Enter your characters (Strength) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute);
                newCharacter.Intelligence = ReadInt32($"Enter your characters (Intelligence) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute);
                newCharacter.Agility= ReadInt32($"Enter your characters (Agility) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute);
                newCharacter.Constitution = ReadInt32($"Enter your characters (Constitution) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute);
                newCharacter.Charisma = ReadInt32($"Enter your characters (Charisma) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute);

                var error = newCharacter.Validate();
                if (String.IsNullOrEmpty(error))
                {
                    character = newCharacter;
                    return;
                }

                DisplayError(error);
            } while (true);
        }

        static void ViewCharacter ()
        {
            Console.WriteLine("View Character");
            //TODO: View Character
        }

        static void EditCharacter ()
        {
            Console.WriteLine("Edit Character");
            //TODO: Edit Character
            //TODO: Confirmation
            //CreateCharacter();
        }

        static void DeleteCharacter ()
        {
            Console.WriteLine("Delete Character");
            //TODO: Delete character
            //TODO: Confirmation
        }
        #endregion
        #region Input Methods
        static string ReadString ( string message, bool required )
        {
            Console.WriteLine(message);

            do
            {
                var input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input) || !required)
                    return input;

                DisplayError("Value is required");
            } while (true);
        }
        static string ChooseFromList ( string selectionType, string[] validSelections, bool required, bool limited )
        {
            var append = limited ? "from this list:" : "";
            Console.WriteLine($"Choose your characters {selectionType} {append}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var s in validSelections)
                Console.WriteLine(s);
            Console.ResetColor();

            do
            {
                var input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input) || !required)
                {
                    if (!limited)
                        return input;
                    foreach (var s in validSelections)
                    {
                        if (String.Equals(input, s, StringComparison.CurrentCultureIgnoreCase))
                            return s;
                    }
                    DisplayError("You must choose a valid character " + selectionType);
                    continue;
                }
                DisplayError("Value is required");
            } while (true);
        }
        static int ReadInt32 ( string message, int minimumValue, int maximumValue )
        {
            Console.WriteLine(message);

            do
            {
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result) && result >= minimumValue && result <= maximumValue)
                    return result;

                DisplayError("The value must be an integral value >= " + minimumValue + " and <= " + maximumValue);
            } while (true);
        }
        static char GetInput ()
        {
            while (true)
            {
                DisplayMenu();
                var input = Console.ReadLine().Trim();

                switch (input.ToUpper())
                {
                    case "C": return 'C';
                    case "V": return 'V';
                    case "E": return 'E';
                    case "D": return 'D';
                    case "Q": return 'Q';
                };

                DisplayError("Invalid Input");
            }
        }
        static bool ReadBoolean ( string message )
        {
            Console.WriteLine(message);

            do
            {
                var input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y)
                    return true;
                else if (input.Key == ConsoleKey.N)
                    return false;
            } while (true);
        }
        #endregion
        #region Display Methods
        static void DisplayIntroduction ()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Jonathan Daniel");
            Console.WriteLine("ITSE 1430 - Fall 2021");
            Console.WriteLine("".PadRight(15, '-'));

            DisplayMenu();
        }
        static void DisplayMenu ()
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
            Console.WriteLine("Q)uit");
        }

        static void DisplayError ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static bool ConfirmQuit ()
        {
            if (ReadBoolean("Are you sure you want to quit (Y/N)?"))
                return true;

            return false;
        }
        #endregion
    }
}
