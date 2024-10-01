using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    //the INotifyPropertyChanged class must be referenced here to allow us to change data and have it update in UI on the fly
    public class Player : INotifyPropertyChanged
    {
        //private values are required here as we cannot use auto-properties to pass values to the viewer
        private string? _name;
        private CharacterClasses _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        //getters simply return whatever value is in the associated private variable
        //setters set the private value to whatever value is passed in, and also activate the OnPropertyChanged method, using the associated value name
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public CharacterClasses CharacterClass;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged("HitPoints");
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged("ExperiencePoints");
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        //constructor for player class
       // public Player()
       // {
       // }

        //event that picks up and sends out info to listeners whenever a property is changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    //CharacterClasses is an enum as there are only a set number of classes to choose from, and this can be added to later here
    public enum CharacterClasses {LostOne,Fighter,Mage,Cleric}
}
