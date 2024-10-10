using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Classes;

namespace Engine.ClassCreator
{
    //making this class static means we don't have to create an instance of this class to run the methods inside it
    //remember that because the WorldFactory class is static (it will never be instantiated), it cannot have a function that requires an instantiated object
    // We can safely make WorldFactory a static class because we are not “maintaining state” in it – we are not holding any variable values inside the static class.
    internal static class WorldFactory
    {
        //simply creates and returns a new world to whatever called it - we can also add all the locations of the world here, provided they meet the criteria given in the world class
        internal static World CreateWorld()
        {
            World gameWorld = new World();

            //add location list here
            //in game locations...
            //also add any quests that are in each location...
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

            //we can add quests here too...
            //this line first finds the location requested, then adds the quest found by ID to the list of quests that are available here. Got it? Good.
            gameWorld.FindLocationAt(0, 0).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));


            return gameWorld;
        }
    }
}
