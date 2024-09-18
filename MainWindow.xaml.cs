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
    }
}