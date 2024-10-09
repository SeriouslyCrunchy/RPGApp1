using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Engine.Classes
{
    //GameItem class will hold all of the values for a game item, these will then be placed in a list in the item factory
    public class GameItem
    {
        //variables that ALL items will need, but does not include variables that only some items will need IE damage
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }

        //standard constructor that sets the initial variables up
        public GameItem(int itemID, string itemName, int itemPrice)
        {
            ItemID = itemID;
            ItemName = itemName;
            ItemPrice = itemPrice;
        }

        //when we create a new instance of this object we clone it using this method
        public GameItem Clone()
        {
            return new GameItem(ItemID, ItemName, ItemPrice);
        }

    }
}
