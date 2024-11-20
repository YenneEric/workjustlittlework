using System.Windows;

namespace View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HomePage.CustomChange += NavigateFromHomePage;
            InsertData.CustomChange += NavigateBackToHome;
            InsertData.AddPlayer += (s, e) => NavigateToAddPlayerPage();
            AddPlayerPage.NavigateBack += (s, e) => NavigateBackToInsertData();

            // Add CustomChange handlers for other pages
            MostTouchdowns.CustomChange += NavigateBackToHome;
            TopScoring.CustomChange += NavigateBackToHome;
            ConfrenceWins.CustomChange += NavigateBackToHome;
            MostTeamYards.CustomChange += NavigateBackToHome;
        }

        private void NavigateFromHomePage(object? sender, CustomizeEventArgs e)
        {
            HideAllPages();

            switch (e.Name)
            {
                case "InsertButton":
                    InsertData.Visibility = Visibility.Visible;
                    break;
                case "MostTd":
                    MostTouchdowns.Visibility = Visibility.Visible;
                    break;
                case "TopScoring":
                    TopScoring.Visibility = Visibility.Visible;
                    break;
                case "ConfrenceWins":
                    ConfrenceWins.Visibility = Visibility.Visible;
                    break;
                case "MostTeamYards":
                    MostTeamYards.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void NavigateBackToHome(object? sender, RoutedEventArgs e)
        {
            HideAllPages();
            HomePage.Visibility = Visibility.Visible;
        }

        private void NavigateToAddPlayerPage()
        {
            HideAllPages();
            AddPlayerPage.Visibility = Visibility.Visible;
        }

        private void NavigateBackToInsertData()
        {
            HideAllPages();
            InsertData.Visibility = Visibility.Visible;
        }

        private void HideAllPages()
        {
            HomePage.Visibility = Visibility.Hidden;
            InsertData.Visibility = Visibility.Hidden;
            AddPlayerPage.Visibility = Visibility.Hidden;
            MostTouchdowns.Visibility = Visibility.Hidden;
            ConfrenceWins.Visibility = Visibility.Hidden;
            MostTeamYards.Visibility = Visibility.Hidden;
            TopScoring.Visibility = Visibility.Hidden;
        }
    }
}
