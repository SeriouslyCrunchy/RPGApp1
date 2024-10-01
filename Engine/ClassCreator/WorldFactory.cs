using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Classes;

namespace Engine.ClassCreator
{
    internal class WorldFactory
    {
        //simply creates and returns a new world to whatever called it - we can also add all the locations of the world here, provided they meet the criteria given in the world class
        internal World CreateWorld()
        {
            World gameWorld = new World();

            //add location list here
            gameWorld.AddLocation(0, 0, "Abandoned Hut",
            "The hut where you awoke, enough to provide some, albeit poor, shelter from the elements",
            "pack://application:,,,/Engine;component/Images/Locations/DSC_1065.JPG");

            gameWorld.AddLocation(0, 1, "North Path",
            "A path to the north",
            "pack://application:,,,/Engine;component/Images/Locations/DSC_0904.JPG");

            gameWorld.AddLocation(1, 0, "East Path",
            "A path to the East",
            "pack://application:,,,/Engine;component/Images/Locations/DSC_0935.JPG");

            gameWorld.AddLocation(0, -1, "South Path",
            "A path to the South",
            "pack://application:,,,/Engine;component/Images/Locations/DSC_1002.JPG");

            gameWorld.AddLocation(-1, 0, "West Path",
            "A path to the West",
            "pack://application:,,,/Engine;component/Images/Locations/DSC_1002.JPG");


            return gameWorld;
        }
    }
}
