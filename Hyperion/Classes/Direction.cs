using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion
{
    public struct Direction
    {
        public const string North="north"; //Constant! It is burned in! Cannot change it once declared.
        public const string South = "south";
        public const string East = "east";
        public const string West = "west";

        public static bool IsValidDirection(string direction)
        {
            return true;
        }
    }
}
