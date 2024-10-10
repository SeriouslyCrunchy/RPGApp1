using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    //this quest class holds everything a quest needs : an ID, a name, a description, the items needed to complete the quest,
    //any rewards including exp, gold, items...
    //all of these must have getters and setters and also have a constructor to get the class started
    public class Quest
    {
        public int QuestID { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public List<ItemQuantity> QuestItemsToComplete { get; set; }
        public int QuestRewardExperiencePoints { get; set; }
        public int QuestRewardGold { get; set; }
        public List<ItemQuantity> QuestRewardItems { get; set; }
        public Quest(int id, string name, string description, List<ItemQuantity> itemsToComplete,
                     int rewardExperiencePoints, int rewardGold, List<ItemQuantity> rewardItems)
        {
            QuestID = id;
            QuestName = name;
            QuestDescription = description;
            QuestItemsToComplete = itemsToComplete;
            QuestRewardExperiencePoints = rewardExperiencePoints;
            QuestRewardGold = rewardGold;
            QuestRewardItems = rewardItems;
        }
    }
}
