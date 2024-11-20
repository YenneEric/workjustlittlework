


using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using PersonData;

namespace View
{
    public partial class InsertData : UserControl
    {
        private readonly ISelect _repository;
        public List<string> PlayerNames { get; set; } = new List<string>(); // Initialized to an empty list

        public event EventHandler<RoutedEventArgs>? CustomChange;
        public event EventHandler? AddPlayer;

        public InsertData()
        {
            InitializeComponent();

            const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
            _repository = new SqlSelectRepository(connectionString);

            LoadPlayerData();
        }

        private void LoadPlayerData()
        {
            try
            {
                // Fetch team data for "Kansas State Wildcats"
                var team = _repository.GetTeams(teamName: "Kansas State Wildcats").FirstOrDefault();
                if (team == null)
                {
                    MessageBox.Show("Team 'Kansas State Wildcats' not found.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Fetch season data for the year 2019
                var season = _repository.GetSeasons(year: 2019).FirstOrDefault();
                if (season == null)
                {
                    MessageBox.Show("Season for the year 2019 not found.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Fetch players for the team and season
                var teamPlayers = _repository.GetTeamPlayers(teamId: team.TeamId, seasonId: season.SeasonId);
                if (teamPlayers.Count == 0)
                {
                    MessageBox.Show("No players found for 'Kansas State Wildcats' in 2019.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Fetch player details and bind to ListView
                PlayerNames = new List<string>();
                foreach (var teamPlayer in teamPlayers)
                {
                    var player = _repository.GetPlayers(playerId: teamPlayer.PlayerId).FirstOrDefault();
                    if (player != null)
                    {
                        PlayerNames.Add($"{player.PlayerName} ({player.Position})");
                    }
                }

                DataContext = this; // Set the DataContext for data binding
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            CustomChange?.Invoke(this, new RoutedEventArgs());
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer?.Invoke(this, EventArgs.Empty);
        }
    }
}
