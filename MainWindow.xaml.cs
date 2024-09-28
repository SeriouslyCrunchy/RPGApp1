using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//need a reference to the other classes we want to use
using Engine.ClassViewer;

//namespace of this project so we know where to find it
namespace RPGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession NewGameSession;

        //initialise the window as part of the constructor, set up a new GameSession instance, and add it to the Data Context variable (this will be used later for xaml)
        public MainWindow()
        {
            InitializeComponent();
            NewGameSession = new GameSession();
            DataContext = NewGameSession;
        }

        //methods for clicking specific buttons in the UI, these will be adjusted later, the button names are referenced in the xaml
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NewGameSession.CurrentPlayer.ExperiencePoints = NewGameSession.CurrentPlayer.ExperiencePoints + 10;
            if (NewGameSession.CurrentPlayer.ExperiencePoints >= 100)
            {
                NewGameSession.CurrentPlayer.Level++;
                NewGameSession.CurrentPlayer.ExperiencePoints = 0;
            }
        }
        //these methods reference the movement functions in the GameSession class
        private void ButtonNorth_OnClick(object sender, RoutedEventArgs e)
        {
            NewGameSession.MoveNorth();
            
        }
        private void ButtonSouth_OnClick(object sender, RoutedEventArgs e)
        {
            NewGameSession.MoveSouth();
            
        }
        private void ButtonEast_OnClick(object sender, RoutedEventArgs e)
        {
            NewGameSession.MoveEast();
            
        }
        private void ButtonWest_OnClick(object sender, RoutedEventArgs e)
        {
            NewGameSession.MoveWest();
            
        }
    }
}