﻿using PersonData.Models;
using System.Windows;

namespace View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Subscribe to events for page navigation
            HomePage.CustomChange += NavigateFromHomePage;
            InsertData.CustomChange += NavigateBackToHome;
            InsertData.AddPlayer += (s, e) => NavigateToAddPlayerPage();
            InsertData.AddGame += (s, e) => NavigateToAddGamePage();
            InsertData.EditPlayer += (s, e) => NavigateToEditPlayer();
            InsertData.EditGame += (s, e) => NavigateToEditGame();
            InsertData.ViewStats += (s, e) => NavigateToViewStats();
            InsertData.EditStats += (s, e) => NavigateToEditStats();



            MostTouchdowns.CustomChange += NavigateBackToHome;
            MostTeamYards.CustomChange += NavigateBackToHome;
            TopScoring.CustomChange += NavigateBackToHome;
            //ConfrenceWins.CustomChange += NavigateBackToHome;
            AddSeasonTeamOrConference.CustomChange += NavigateBackToHome;
            ConfrenceTeamRank.CustomChange += NavigateBackToHome;


            AddPlayerPage.NavigateBack += (s, e) => NavigateBackToInsertData();
            AddGame.NavigateBack += (s, e) => NavigateBackToInsertData();
            EditPlayer.NavigateBack += (s, e) => NavigateBackToInsertData();
            EditGame.NavigateBack += (s, e) => NavigateBackToInsertData();
            ViewStats.NavigateBack += (s, e) => NavigateBackToInsertData();
            EditStats.NavigateBack += (s, e) => NavigateBackToInsertData();




        }



        private void NavigateFromHomePage(object? sender, CustomizeEventArgs e)
        {
            HideAllPages();

            // Show the appropriate page based on the button clicked
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
                    ConfrenceTeamRank.Visibility = Visibility.Visible;
                    break;
                case "MostTeamYards":
                    MostTeamYards.Visibility = Visibility.Visible;
                    break;
                case "AddSeasonTeamOrConference": // Correct button name
                    AddSeasonTeamOrConference.Visibility = Visibility.Visible; // Show the correct UserControl
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

        private void NavigateToAddGamePage()
        {
            HideAllPages();
            AddGame.Visibility = Visibility.Visible;
        }

        private void NavigateToEditPlayer()
        {
            HideAllPages();
            EditPlayer.Visibility = Visibility.Visible;
        }

        private void NavigateToEditGame()
        {
            HideAllPages();
            EditGame.Visibility = Visibility.Visible;
        }

        private void NavigateToViewStats()
        {
            HideAllPages();
            ViewStats.Visibility = Visibility.Visible;
        }

        private void NavigateToEditStats()
        {
            HideAllPages();
            EditStats.Visibility = Visibility.Visible;
        }


        private void NavigateBackToInsertData()
        {
            HideAllPages();
            InsertData.Visibility = Visibility.Visible;

            // Refresh data on the InsertData page to ensure it reflects any updates
            // InsertData.RefreshData();
        }

        private void HideAllPages()
        {
            // Hide all pages to prepare for navigation
            HomePage.Visibility = Visibility.Hidden;
            InsertData.Visibility = Visibility.Hidden;
            AddPlayerPage.Visibility = Visibility.Hidden;
            AddGame.Visibility = Visibility.Hidden; // Ensure AddGamePage is hidden
            MostTouchdowns.Visibility = Visibility.Hidden;
            ConfrenceTeamRank.Visibility = Visibility.Hidden;
            MostTeamYards.Visibility = Visibility.Hidden;
            TopScoring.Visibility = Visibility.Hidden;
            EditPlayer.Visibility = Visibility.Hidden;
            EditGame.Visibility = Visibility.Hidden;
            ViewStats.Visibility = Visibility.Hidden;
            EditStats.Visibility = Visibility.Hidden;
            AddSeasonTeamOrConference.Visibility = Visibility.Hidden;





        }
    }
}