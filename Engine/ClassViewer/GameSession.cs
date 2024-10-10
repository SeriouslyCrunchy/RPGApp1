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
    //the INotifyPropertyChanged class must be referenced here to allow us to change data and have it update in UI on the fly
    //this is later replaced to inherit BaseNotificationClass, as this class is inheriting INotifyPropertyChanged
    public class GameSession : BaseNotificationClass
    {
        //instance of various classes to set up the game world for instance : Player to create the current player, Location for the current Location, and World for the current World.
        public Player CurrentPlayer {  get; set; }

        private Location _currentLocation;
        public Location CurrentLocation {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                //adjusting these so that they rely on strings less
                OnPropertyChanged(nameof(CurrentLocation));

                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToSouth));

                //as part of the current location we need to sometimes give player quests from the location
                GivePlayerQuestsAtLocation();
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

            CurrentPlayer = new Player
            {
                Name = "Unnamed",
                CharacterClass = CharacterClasses.LostOne,
                HitPoints = 10,
                Gold = 10,
                ExperiencePoints = 0,
                Level = 1
            };

            //this code has been replaced by the code above, which is using named parameters
            /*
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Nameless";
            CurrentPlayer.Gold = 100;
            CurrentPlayer.CharacterClass = CharacterClasses.LostOne;
            CurrentPlayer.Level = 1;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.HitPoints = 10;
            */

            //We can make a change that will allow us to get a World object from the WorldFactory class, without instantiating a WorldFactory object.
            //We do this by making the WorldFactory “static” and then simply calling the method from the class directly
            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.FindLocationAt(0, 0);

            //We can add items directly into the player's inventory here using the function in the item factory and they will show up on game start
            CurrentPlayer.Inventory.Add(GameItemFactory.CreateGameItem(1003));
            CurrentPlayer.Inventory.Add(GameItemFactory.CreateGameItem(1003));

        }

        //functions to move the view point in game
        //you could also put guard clauses here to prevent people from feeding data in that they should not, for instance by running bool checks before any move
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

        //this method checks every quest of data type quest in the CurrentLocation.QuestsAvailableHere list.
        //using LINQ (query language for lists)
        //if NONE OF of the quest IDs (we are calling inverse any, so the result of the if is true if none of them match)
        //in the player quest list (quests that the player currently has) 
        //match the current Quest ID being searched
        //add it to the players list
       
        private void GivePlayerQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.QuestID == quest.QuestID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }
       


        //this must be activated each time you need to change something in the UI otherwise it wont update
        //this is later removed as this method is now inherited
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
