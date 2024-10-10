using System;
using Engine.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ClassCreator
{
    //as in other factories this quest factory will be static and have a static method that can be used to create quests
    internal static class QuestFactory
    {
        //create a list of quests
        private static readonly List<Quest> _quests = new List<Quest>();

        //then fill it with this static method
        static QuestFactory()
        {
            // Declare the items need to complete the quest, and its reward items
            List<ItemQuantity> itemsToComplete = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();
            itemsToComplete.Add(new ItemQuantity(801,2));
            itemsToComplete.Add(new ItemQuantity(802,1));
            itemsToComplete.Add(new ItemQuantity(803,2));
            rewardItems.Add(new ItemQuantity(901,1));
            // Create the quest
            
            _quests.Add(new Quest(1,
                                  "Create some sort of tool to help you survive",
                                  "Search the surrounding paths and find some branches, a rope and a rock that you can combine together",
                                  itemsToComplete,
                                  25, 10,
                                  rewardItems));
            
        }
        internal static Quest GetQuestByID(int id)
        {
            return _quests.FirstOrDefault(quest => quest.QuestID == id);
        }
    }
}
