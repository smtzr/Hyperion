using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion
{
    static class Level
    {
        private static Room[,] rooms;

        #region properties
        public static Room[,] Rooms
        {
            get { return rooms; }
        }
        #endregion

        public static void Initialize()
        {
            BuildLevel();
        }

        private static void BuildLevel()
        {
            rooms = new Room[2, 2];

            Room room;
            Item item;

            // create a new room
            room = new Room();

            //Assign this room to location 0, 0
            rooms[0, 0] = room;

            //Setup the room
            room.Title = "Red Room";
            room.Description = "You have entered a red room. There is a locked door to the south";
            room.AddExit(Direction.East);
            //Create a new item

            item = new Item();
            item.Title = "Blue Ball";
            item.PickupText = "You have picked up a blue ball";
            room.Items.Add(item);


            // create a new room
            room = new Room();
            //Assign this room to location 0, 0
            rooms[1, 0] = room;

            //Setup the room
            room.Title = "Blue Room";
            room.Description = "You have entered a blue room";
            room.AddExit(Direction.West);
            room.AddExit(Direction.South);
            
            item = new Item();
            item.Title = "Anvil";
            item.PickupText = "You struggle to pick up the anvil";
            item.Weight = 6;
            room.Items.Add(item);

            item = new Item();
            item.Title = "Green Ball";
            item.PickupText = "You have picked up a Green Ball";
            room.Items.Add(item);

            item = new Item();
            item.Title = "Key";
            item.PickupText = "You have picked up a key";
            room.Items.Add(item);

            room = new Room();
            rooms[0, 1] = room;
            room.Title = "Green Room";
            room.Description = "You have entered a green room. There is a locked door to the north.";
            room.AddExit(Direction.East);

            item = new Item();
            item.Title = "Yellow Ball";
            item.PickupText = "You have picked up a yellow ball";
            room.Items.Add(item);




            room = new Room();
            rooms[1, 1] = room;
            room.Title = "Yellow Room";
            room.Description = "You have entered a yellow room";
            room.AddExit(Direction.North);
            room.AddExit(Direction.West);

            item = new Item();
            item.Title = "Red Ball";
            item.PickupText = "You have picked up a red ball";
            room.Items.Add(item);

            //Place the player in the starting room.
            Player.PosX = 0;
            Player.PosY = 0;


        }


    }
}
