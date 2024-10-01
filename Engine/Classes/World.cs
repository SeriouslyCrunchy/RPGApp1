using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class World
    {
        //we need a new list of location classes, and a way to add them from a sort of database - so, create a new list, and a method that allows us to add location variables to it
        private List<Location> _locations = new List<Location>();
        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            Location loc = new Location();
            loc.XCoordinate = xCoordinate;
            loc.YCoordinate = yCoordinate;
            loc.LocationName = name;
            loc.LocationDescription = description;
            loc.LocationImageFile = imageName;
            _locations.Add(loc);


        }
        //we now need a way to find a specific location via X/Y co-ords. This method should loop through all locations in the location list, and return it, returning null if none is found
        public Location FindLocationAt(int xCoordinate, int yCoordinate)
        {
            foreach (Location loc in _locations)
            {
                if (loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate)
                {
                    //remember returning ejects from the loop
                    return loc;
                }
            }
            return null;
        }
    }

}
