/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;

namespace JonaDaniel.AdventureGame.ConsoleHost
{
    class Program
    {
        public static int currentRoom = 8;
        private static int s_moveIndex = 0;
        static void Main ( string[] args )
        {
            DisplayIntroduction();

            bool done = false;

            do
            {
                string command = GetInput();

                switch (command)
                {
                    case "quit": done = HandleQuit(); break;
                    case "help": HelpList(); break;
                    case "look": SearchArea(); break;
                    case "move":
                    case "movenorth": s_moveIndex = 0; MoveNorth(); break;
                    case "moveeast": s_moveIndex = 1; MoveEast(); break;
                    case "movesouth": s_moveIndex = 2; MoveSouth(); break;
                    case "movewest": s_moveIndex = 3; MoveWest(); break;
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
            Console.WriteLine("Move | MoveNorth | MoveEast | MoveSouth | MoveWest ::= Move in the indicated direction");
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
        static void SearchArea ()
        {
            //TODO: Later
            Console.WriteLine("You search");
            World();
        }
        static void MoveNorth ()
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

        #region Game World
        static void World ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("World");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            var empty = "".PadRight(11, ' ') + "|".PadRight(12, ' ') + "|".PadRight(11, ' ');
            Console.WriteLine(empty);
            Console.WriteLine("  Room 1   |  Room 2   |  Room 3  ");
            Console.WriteLine("  Kitchen  |  Stairs   |  Closet  ");
            Console.WriteLine(empty);
            Console.WriteLine("".PadRight(35, '-'));
            Console.WriteLine(empty);
            Console.WriteLine("  Room 4   |  Room 5   |  Room 6  ");
            Console.WriteLine("  Dining   |  Hallway  | Bathroom ");
            Console.WriteLine(empty);
            Console.WriteLine("".PadRight(35, '-'));
            Console.WriteLine(empty);
            Console.WriteLine("  Room 7   |  Room 8   |  Room 9  ");
            Console.WriteLine(" Paintings | Entrance  |  Sitting ");
            Console.WriteLine(empty);

            //Basic Design

            //Console.WriteLine(" Kitche | Upstai | Closet ");
            //Console.WriteLine(" Room 1 | Room 2 | Room 3 ");
            //Console.WriteLine(" Foods  | Notmuc | Clothe ");
            //Console.WriteLine("".PadRight(26, '-'));
            //Console.WriteLine(" Dining | Hallwa | Bathro ");
            //Console.WriteLine(" Room 4 | Room 5 | Room 6 ");
            //Console.WriteLine(" Fooods | Closet | Stuffs ");
            //Console.WriteLine("".PadRight(26, '-'));
            //Console.WriteLine(" Hallwa | Start  | Sit    ");
            //Console.WriteLine(" Room 7 | Room 8 | Room 9 ");
            //Console.WriteLine(" Paints | Front  | Chairs ");
        }

        #region rooms
        static void Room1 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 1");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 1 is a Kitchen");
            Console.WriteLine("Can move East to Room 2");
            Console.WriteLine("Can move South to Room 4");
        }

        static void Room2 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 2");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 2 has a stairway");
            //Console.WriteLine("Can move North to upstairs");
            Console.WriteLine("Can't move North");
            Console.WriteLine("Can move East to Room 3");
            Console.WriteLine("Can move South to Room 5");
            Console.WriteLine("Can move West to Room 1");

            int[] move = { 2, 3, 5, 1 };
            if (currentRoom == move[s_moveIndex])
            {
                DisplayError("Can't move that way right now");
            }
            currentRoom = move[s_moveIndex];
        }

        static void Room3 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 3");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 3 is a closet");
            Console.WriteLine("Can't move North");
            Console.WriteLine("Can't move East");
            Console.WriteLine("Can move South to Room 6");
            Console.WriteLine("Can move West to Room 2");

        }

        static void Room4 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 4");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 4 is a Dining Room");
            Console.WriteLine("Can move North to Room 1");
            Console.WriteLine("Can move East to Room 5");
            Console.WriteLine("Can move South to Room 7");
            Console.WriteLine("Can't move West");
        }

        static void Room5 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 5");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 5 is a Hallway");
            Console.WriteLine("Can move North to Room 2");
            Console.WriteLine("Can move East to Room 6");
            Console.WriteLine("Can move South to Room 8");
            Console.WriteLine("Can move West to Room 4");
        }

        static void Room6 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 6");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 6 is a Bathroom");
            Console.WriteLine("Can move North to Room 3");
            Console.WriteLine("Can't move East");
            Console.WriteLine("Can move South to Room 9");
            Console.WriteLine("Can move West to Room 5");
        }

        static void Room7 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 7");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 7 is a Painting Display Room");
            Console.WriteLine("Can move North to Room 4");
            Console.WriteLine("Can move East to Room 8");
            Console.WriteLine("Can't move South");
            Console.WriteLine("Can't move West");
        }

        static void Room8 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 8");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 8 is a Dining Room");
            Console.WriteLine("Can move North to Room 5");
            Console.WriteLine("Can move East to Room 9");
            //Console.WriteLine("Can move South to Outside");
            Console.WriteLine("Can't move South");
            Console.WriteLine("Can move West to Room 7");
        }

        static void Room9 ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("Room 9");
            Console.WriteLine("".PadRight(35, '='));
            Console.ResetColor();

            Console.WriteLine("Room 9 is a Living Room");
            Console.WriteLine("Can move North to Room 6");
            Console.WriteLine("Can't move East");
            Console.WriteLine("Can't move South");
            Console.WriteLine("Can move West to Room 8");
        }
        #endregion

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
        static string GetInput ()
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
