using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion //They deleted the namespace in order to access it within the main method. They hold everything "in a giant Tupperware box"
{
    static class GameManager
    {
        // Public Methods
        public static void ShowTitleScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(TextUtils.WordWrap("*** The Hyperion Project *** An XNA Xtreme 101 game by 3d Buzz \n\n\n", Console.WindowWidth));
            Console.WriteLine("\nNOTE: You may type 'help' at any time to see the a list of commands");
            Console.WriteLine("\nPress a key to begin");

            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
            Console.Clear();
        }

        public static void StartGame()
        {
            Player.GetCurrentRoom().Describe();
            TextBuffer.Display();
        }

        public static void EndGame(string endingText)
        {
            Program.quit = true;

            Console.Clear();

            Console.WriteLine(TextUtils.WordWrap(endingText, Console.WindowWidth));
            Console.WriteLine("\nYou may now close the window");
            Console.CursorVisible = false;

            while (true)
            {
                Console.ReadKey(true);
            }
        }

        public static void ApplyRules()
        {
            if (Level.Rooms[0, 0].GetItem("Red Ball") != null &&
                Level.Rooms[1, 0].GetItem("Blue Ball") != null &&
                Level.Rooms[0, 1].GetItem("Green Ball") != null &&
                Level.Rooms[1, 1].GetItem("Yellow Ball") != null
                )
            {
                EndGame("You have placed the right item to its right slot");
            }

            if (Player.GetInventoryItem("Key") != null)
            {
                Level.Rooms[0, 0].AddExit(Direction.South);
                Level.Rooms[0, 0].Description = "You have entered a red room.";
                Level.Rooms[0, 1].AddExit(Direction.North);
                Level.Rooms[0, 1].Description = "You have entered a green room.";
            }

            if (Player.Moves > 20)
            {
                EndGame("You are old and slow. You die");
            }
        }


    }
}
