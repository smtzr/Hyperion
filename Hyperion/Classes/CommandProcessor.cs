using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion
{
    static class CommandProcessor
    {
        public static void ProcessCommand(string line)
        {
            string command = TextUtils.ExtractCommand(line.Trim()).Trim().ToLower();
            string arguments = TextUtils.ExtractArguments(line.Trim()).Trim().ToLower();

            switch (command)
            {
                case "exit":
                    Program.quit = true;
                    return;
                case "help":
                    ShowHelp();
                    break;
                case "move":
                    Player.Move(arguments);
                    break;
                case "look":
                    Player.GetCurrentRoom().Describe();
                    break;
                case "pickup":
                    Player.PickupItem(arguments);
                    break;
                case "drop":
                    Player.DropItem(arguments);
                    break;
                case "inventory":
                    Player.DisplayInventory();
                    break;
                case "wherami":
                    Player.GetCurrentRoom().ShowTitle();
                    break;
                default:
                    TextBuffer.Add("Input not understood");
                    break;
                    
            }
            GameManager.ApplyRules();
            TextBuffer.Display();
        }

        public static void ShowHelp()
        {
            TextBuffer.Add("Available Commands:");
            TextBuffer.Add("--------------------");
            TextBuffer.Add("help");
            TextBuffer.Add("exit");
            TextBuffer.Add("move(north south,east,west)");
            TextBuffer.Add("pickup");
            TextBuffer.Add("look");
            TextBuffer.Add("inventory");
            TextBuffer.Add("drop");
            TextBuffer.Add("whereami");
            
        }

        
    }
}
