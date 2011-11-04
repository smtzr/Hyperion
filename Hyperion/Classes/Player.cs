using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion
{
    static class Player
    {
        private static int posX;
        private static int posY;

        private static List<Item> inventoryItems;
        private static int moves = 0;
        private static int weightCapacity = 6;

        #region properties

        public static int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public static int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public static int Moves
        {
            get { return moves; }
            set { moves = value; }
        }

        public static int WeightCapacity
        {
            get { return weightCapacity; }
            set { weightCapacity = value; }
        }

        public static int InventoryWeight
        {
            get 
            {
                int result = 0;
                foreach (Item item in inventoryItems)
                {
                    result += item.Weight;
                }

                return result;
            }
        }
        #endregion

        static Player()
        {
            inventoryItems = new List<Item>();

        }

        #region Public Methods

        public static void Move(string direction)
        {
            Room room = Player.GetCurrentRoom();

            if (!room.CanExit(direction))
            {
                TextBuffer.Add("Invalid Direction");
                return;
            }

            Player.moves++;

            switch (direction)
            {
                case Direction.North:
                    posY--;
                    break;
                case Direction.South:
                    posY++;
                    break;
                case Direction.East:
                    posX++;
                    break;
                case Direction.West:
                    posX--;
                    break;
            }

            Player.GetCurrentRoom().Describe();
        }

        public static void PickupItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = room.GetItem(itemName);

            if (item != null)
            {
                if (Player.InventoryWeight + item.Weight > Player.weightCapacity)
                {
                    TextBuffer.Add("You must first drop some weight before you can pick up this item");
                    return;
                }

                room.Items.Remove(item);
                Player.inventoryItems.Add(item);
                TextBuffer.Add(item.PickupText);

            }

            else
            {
                TextBuffer.Add("There is no " + itemName + " in this room.");
            }
        }

        public static void DropItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = GetInventoryItem(itemName);

            if (item != null)
            {
                Player.inventoryItems.Remove(item);
                room.Items.Add(item);
                TextBuffer.Add("The" + itemName + " has been dropped into this room");
            }
            else
                TextBuffer.Add("There is no " + itemName + " in your inventory");
        }

        public static void DisplayInventory()
        {
            string message = "Your Inventory contains:";
            string items = "";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (inventoryItems.Count > 0)
            {
                foreach (Item item in inventoryItems)
                {
                    items += "\n[" + item.Title + "] Wt: " + item.Weight.ToString();
                }
            }
            else
            {
                items = "\n<no items>";
            }
            items += "\n\nTotal Wt: " + Player.InventoryWeight + " / " + Player.WeightCapacity;

            TextBuffer.Add(message + "\n" + underline + items);
        }

        public static Room GetCurrentRoom()
        {
            return Level.Rooms[posX, posY];
        }

        public static Item GetInventoryItem(string itemName)
        {
            foreach (Item item in inventoryItems)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                    return item;
            }
            return null;
        } 
        #endregion

    }
}
