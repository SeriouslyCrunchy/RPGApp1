using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    //the INotifyPropertyChanged class must be referenced here to allow us to change data and have it update in UI on the fly
    //this is later replaced to inherit BaseNotificationClass, as this class is inheriting INotifyPropertyChanged
    public class Player : BaseNotificationClass
    {
        //private values are required here as we cannot use auto-properties to pass values to the viewer
        private string? _name;
        //private CharacterClasses _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        //getters simply return whatever value is in the associated private variable
        //setters set the private value to whatever value is passed in, and also activate the OnPropertyChanged method, using the associated value name
        //adjusting the onpropertychanged values to be more efficent by removing strings
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public CharacterClasses CharacterClass;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        //here we want a way to process items in a list and present them in a way the player can see
        //the best way to do this is with an ObservableCollection, as this also automatically updates the UI
        //and so does not require an OnPropertyChanged statement
        public ObservableCollection<GameItem> Inventory { get; set; }

        public ObservableCollection<QuestStatus> Quests { get; set; }

        ////this must be initialised and is best done in a constructor
        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();

            Quests = new ObservableCollection<QuestStatus>();
        }

        //this must be activated each time you need to change something in the UI otherwise it wont update
        //this is later removed as this method is now inherited
        /*public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        */

    }



    //CharacterClasses is an enum as there are only a set number of classes to choose from, and this can be added to later here
    public enum CharacterClasses {LostOne,Fighter,Mage,Cleric}
}
