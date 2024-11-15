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

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HomePage.CustomChange += InsertClick;
            InsertData.CustomChange += BackHome;
            MostTouchdowns.CustomChange += BackHome;
            TopScoring.CustomChange += BackHome;
            ConfrenceWins.CustomChange += BackHome;
            MostTeamYards.CustomChange += BackHome;


        }


        private void InsertClick(object? sender, CustomizeEventArgs e)
        {
            string name = e.Name;
            


            if(name == "InsertButton")
            {
                HomePage.Visibility = Visibility.Hidden;
                InsertData.Visibility = Visibility.Visible;
            }
            else if(name == "MostTd")
            {
                HomePage.Visibility = Visibility.Hidden;
                MostTouchdowns.Visibility = Visibility.Visible;
            }
            else if (name == "TopScoring")
            {
                HomePage.Visibility = Visibility.Hidden;
                TopScoring.Visibility = Visibility.Visible;
            }
            else if (name == "ConfrenceWins")
            {
                HomePage.Visibility = Visibility.Hidden;
                ConfrenceWins.Visibility = Visibility.Visible;
            }
            else if (name == "MostTeamYards")
            {
                HomePage.Visibility = Visibility.Hidden;
                MostTeamYards.Visibility = Visibility.Visible;
            }




        }

        private void BackHome(object? sender, RoutedEventArgs e)
        {
            HomePage.Visibility = Visibility.Visible;
            InsertData.Visibility = Visibility.Hidden;
            MostTouchdowns.Visibility = Visibility.Hidden;
            TopScoring.Visibility = Visibility.Hidden;
            ConfrenceWins.Visibility = Visibility.Hidden;
            MostTeamYards.Visibility = Visibility.Hidden;
        }




    }
}