using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Location
    {
        //declare location class variables
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string LocationImageFile { get; set; }

        //we need a new property - this must handle a list of quest objects stating what quests are available in this location
        //we dont want to have to run a constructor, so we instantiate it as a new list of quests titled QuestsAvailableHere
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();
    }
}
