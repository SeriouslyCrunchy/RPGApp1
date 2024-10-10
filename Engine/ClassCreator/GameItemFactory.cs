using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Classes;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Engine.ClassCreator
{
    //the purpose of this class is to build game items that can be used elsewhere
    //it will construct gameitems based on the GameItem class in Classes folder, which will also have a Weapon subclass
    //it will be static as we only need it to run the functions within it and store things, not for anything else - but it must still be public so that other people can access it
    public static class GameItemFactory
    {
        //we need a static list and a static Factory function to fill that list
        private static List<GameItem> _standardGameItems;

        //this static constructor simply creates a new list and then adds all the items below into it.
        //the items are effectively 'created' here with the right parameters required as part of the gameitem class, and, if applicable, the weapon class 
        //at this point it's usually helpful to remember to create things like item IDs with some sort of system. 
        //for instance, starting items could be 1XX, weapons could be 2XX, armour 3XX, usable items 4XX, and so on
        static GameItemFactory()
        {
            _standardGameItems = new List<GameItem>();
            _standardGameItems.Add(new GameItem(401, "Potion", 3));
            _standardGameItems.Add(new GameItem(402, "Fire Bomb", 5));
            _standardGameItems.Add(new Weapon(101, "Pointy Stick", 1, 1, 2));
            _standardGameItems.Add(new Weapon(204, "Rusty Sword", 5, 1, 3));
            _standardGameItems.Add(new GameItem(901, "Makeshift Hammer", 3));
            _standardGameItems.Add(new GameItem(801, "Sturdy Branch", 2));
            _standardGameItems.Add(new GameItem(802, "Robust Rock", 2));
            _standardGameItems.Add(new GameItem(803, "Fibrous Stalk", 2));
        }

        //this function is how we create a specific instatiated item of a standard item type. it also allows us to modify that item later if we wish
        public static GameItem CreateGameItem(int itemID)
        {
            //this will look for an item with the same ID as the one given in the item list and then create and instance of it, provided the item returned isnt null
            //(which it should never be, but we must have this check in place here just in case)
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemID == itemID);

            if (standardItem != null)
            {
                return standardItem.Clone();
            }
            return null;
        }
    }
}
