using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    //this class will inherit from the main gameitem class - and will add further values that only weapons will have such as damage
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        //when creating a new weapon in the constructor, we need to use the base(inherited) values where possible,
        //and then have additional values on top of that for things unique to a weapon item
        public Weapon(int itemID, string itemName, int itemPrice, int minDamage, int maxDamage)
            : base(itemID, itemName, itemPrice)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        //when we create a new instance of this object we clone it using this method
        public new Weapon Clone()
        {
            return new Weapon(ItemID, ItemName, ItemPrice, MinimumDamage, MaximumDamage);
        }
    }
}
