using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//must use Engine.Classes as that is where the player class resides
using Engine.Classes;
using Engine.ClassCreator;
using System.ComponentModel;

namespace Engine.ClassViewer
{
    public class GameSession : INotifyPropertyChanged
    {
        //instance of various classes to set up the game world for instance : Player to create the current player, Location for the current Location, and World for the current World.
        public Player CurrentPlayer {  get; set; }

        private Location _currentLocation;
        public Location CurrentLocation {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged("CurrentLocation");

                OnPropertyChanged("HasLocationToNorth");
                OnPropertyChanged("HasLocationToEast");
                OnPropertyChanged("HasLocationToWest");
                OnPropertyChanged("HasLocationToSouth");
            }
        }
        public World CurrentWorld { get; set; }

        //these boolean parameters check if there are valid locations to the North/South/East/West by finding the locations adjacent to 
        public bool HasLocationToNorth
        {
            get
            {
                return CurrentWorld.FindLocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
            }
        }
        public bool HasLocationToEast
        {
            get
            {
                return CurrentWorld.FindLocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
            }
        }
        public bool HasLocationToSouth
        {
            get
            {
                return CurrentWorld.FindLocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
            }
        }
        public bool HasLocationToWest
        {
            get
            {
                return CurrentWorld.FindLocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
            }
        }


        //constructor for the game session creates classes where necessary and fills them with basic info
        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Nameless";
            CurrentPlayer.Gold = 100;
            CurrentPlayer.CharacterClass = CharacterClasses.LostOne;
            CurrentPlayer.Level = 1;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.HitPoints = 10;

            //This will be replaced by a world creator or factory
            /*
            CurrentLocation = new Location();
            CurrentLocation.LocationName = "Ruins";
            CurrentLocation.LocationDescription = "The ruins where you awoke, enough to provide some, albeit poor, shelter from the elements";
            CurrentLocation.XCoordinate = 0;
            CurrentLocation.YCoordinate = 0;
            CurrentLocation.LocationImageFile = "pack://application:,,,/Engine;component/Images/Locations/DSC_0904.png";
            */

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();
            CurrentLocation = CurrentWorld.FindLocationAt(0, 0);

        }

        //functions to move the view point in game
        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.FindLocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }
        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.FindLocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }
        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.FindLocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }
        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.FindLocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }



        //this must be activated each time you need to change something in the UI otherwise it wont update
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
