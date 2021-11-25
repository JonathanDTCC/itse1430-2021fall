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

        private static Character character;
        #region Character Methods
        /// <summary>
        /// Creates a character
        /// </summary>
        private static void CreateCharacter ()
        {
            var newCharacter = new Character();

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
        /// <summary>
        /// Views Character if one has been created
        /// </summary>
        private static void ViewCharacter ()
        {
            if (character == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to create a character before you can view it");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Character:");
            Console.ResetColor();

            Console.WriteLine($"Name: {character.Name}");
            Console.WriteLine($"Profession: {character.Profession}");
            Console.WriteLine($"Race: {character.Race}");
            Console.WriteLine(character.Biography);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Attributes:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Strength: [{character.Strength}]");
            Console.WriteLine($"Intelligence: [{character.Intelligence}]");
            Console.WriteLine($"Agility: [{character.Agility}]");
            Console.WriteLine($"Constitution: [{character.Constitution}]");
            Console.WriteLine($"Charisma: [{character.Charisma}]");
            Console.ResetColor();
        }
        /// <summary>
        /// Allows user to edit or choose to create a character
        /// </summary>
        private static void EditCharacter ()
        {
            if (character == null)
            {
                if (ReadBoolean("No defined character exists, would you like to create a new one(Y/N)?"))
                {
                    CreateCharacter();
                    return;
                }
                return;
            }

            Console.WriteLine("This is your current character");
            ViewCharacter();

            var newCharacter = new Character();

            do
            {
                newCharacter.Name = ReadBoolean($"Characters name is currently |{character.Name}| do you want to change it? (Y/N)") ?
                                    ReadString("Enter your characters name: ", true) : character.Name;

                newCharacter.Profession = ReadBoolean($"Characters profession is currently |{character.Profession}| do you want to change it? (Y/N)") ?
                                        ChooseFromList("Profession", Character.ValidProfessions, true, true) : character.Profession;
                newCharacter.Race = ReadBoolean($"Characters race is currently |{character.Race}| do you want to change it? (Y/N)") ?
                                    ChooseFromList("Race", Character.ValidRaces, true, true) : character.Race;

                newCharacter.Biography = (character.Biography == "") ?
                                        ReadBoolean("Would you like to add a Biography entry to your character? (Y/N)") ?
                                                    ReadString("Enter an optional biography for your character", false) : "" :
                                        ReadBoolean($"Characters biography currently reads: |{character.Biography}| do you want to change it? (Y/N)") ?
                                                    ReadString("Enter an optional biography for your character", false) : character.Biography;

                newCharacter.Strength = ReadBoolean($"Characters Strength is currently |{character.Strength}| do you want to change it? (Y/N)") ?
                                        ReadInt32($"Enter your characters (Strength) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute) : character.Strength;
                newCharacter.Intelligence = ReadBoolean($"Characters Intelligence is currently |{character.Intelligence}| do you want to change it? (Y/N)") ?
                                        ReadInt32($"Enter your characters (Intelligence) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute) : character.Intelligence;
                newCharacter.Agility = ReadBoolean($"Characters Agility is currently |{character.Agility}| do you want to change it? (Y/N)") ?
                                        ReadInt32($"Enter your characters (Agility) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute) : character.Agility;
                newCharacter.Constitution = ReadBoolean($"Characters Constitution is currently |{character.Constitution}| do you want to change it? (Y/N)") ?
                                        ReadInt32($"Enter your characters (Constitution) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute) : character.Constitution;
                newCharacter.Charisma = ReadBoolean($"Characters Charisma is currently |{character.Charisma}| do you want to change it? (Y/N)") ?
                                        ReadInt32($"Enter your characters (Charisma) Attribute Values - Range: ({Character.MinAttribute} - {Character.MaxAttribute})", Character.MinAttribute, Character.MaxAttribute) : character.Charisma;

                var error = newCharacter.Validate();
                if (String.IsNullOrEmpty(error))
                {
                    character = newCharacter;
                    return;
                }

                DisplayError(error);
            } while (true);
        }

        private static void DeleteCharacter ()
        {
            if (character == null)
            {
                DisplayError("There is no character to delete");
                return;
            }

            if (ReadBoolean("Are you sure you want to delete |" + character.Name + "|? (Y/N)"))
            {
                var deletedCharacter = character.ToString();
                character = null;
                DisplayMessage($"Character: {deletedCharacter} was deleted");
                return;
            }
        }
        #endregion
        #region Input Methods
        private static string ReadString ( string message, bool required )
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
        private static string ChooseFromList ( string selectionType, string[] validSelections, bool required, bool limited )
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
        private static int ReadInt32 ( string message, int minimumValue, int maximumValue )
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
        private static char GetInput ()
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
        private static bool ReadBoolean ( string message )
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
        private static void DisplayIntroduction ()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Jonathan Daniel");
            Console.WriteLine("ITSE 1430 - Fall 2021");
            Console.WriteLine("".PadRight(15, '-'));

            DisplayMenu();
        }
        /// <summary>
        /// Displays the Main Menu
        /// </summary>
        private static void DisplayMenu ()
        {
            Console.WriteLine("");
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

        private static void DisplayError ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void DisplayMessage ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static bool ConfirmQuit ()
        {
            if (ReadBoolean("Are you sure you want to quit (Y/N)?"))
                return true;

            return false;
        }
        #endregion
    }
}
