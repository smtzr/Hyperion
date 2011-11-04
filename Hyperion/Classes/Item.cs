using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperion
{
    class Item
    {
        private string title;
        private string pickupText;
        private int weight = 1;

        #region properties
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string PickupText
        {
            get { return pickupText; }
            set { pickupText = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        #endregion
    }
}
