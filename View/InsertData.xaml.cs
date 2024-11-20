using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PersonData;
using PersonData.Models;

namespace View
{
    public partial class InsertData : UserControl
    {
        private readonly IStatRepository _repository;
        private readonly ISelect _selectRepository;

        // Properties for binding
        public List<PlayerDetails> PlayerDetails { get; set; } = new List<PlayerDetails>();
        public List<GameSchedule> ScheduleDetails { get; set; } = new List<GameSchedule>();
        public List<string> Teams { get; set; } = new List<string>();
        public List<int> Years { get; set; } = new List<int>();

        public event EventHandler<RoutedEventArgs>? CustomChange;
        public event EventHandler? AddPlayer;

        public InsertData()
        {
            InitializeComponent();

            const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
            _repository = new SqlTouchDownRepository(connectionString);
            _selectRepository = new SqlSelectRepository(connectionString);

            LoadTeamsAndYears();
            ClearData(); // Initialize with empty data
        }

        // Load teams and years into dropdowns
        private void LoadTeamsAndYears()
        {
            try
            {
                Teams = _selectRepository.GetTeams().Select(t => t.TeamName).ToList();
                TeamComboBox.ItemsSource = Teams;

                Years = _selectRepository.GetSeasons().Select(s => s.Year).OrderByDescending(y => y).ToList();
                YearComboBox.ItemsSource = Years;

                TeamComboBox.SelectedIndex = -1;
                YearComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading teams or years: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Load player and schedule data for the selected team and year
        private void LoadData(string teamName, int year)
        {
            try
            {
                // Load player details
                var team = _selectRepository.GetTeams(teamName: teamName).FirstOrDefault();
                if (team == null)
                {
                    ClearData();
                    return;
                }

                var season = _selectRepository.GetSeasons(year: year).FirstOrDefault();
                if (season == null)
                {
                    ClearData();
                    return;
                }

                PlayerDetails = _selectRepository.GetTeamPlayers(teamId: team.TeamId, seasonId: season.SeasonId)
                    .Select(tp =>
                    {
                        var player = _selectRepository.GetPlayers(playerId: tp.PlayerId).FirstOrDefault();
                        return player != null
                            ? new PlayerDetails
                            {
                                PlayerName = player.PlayerName,
                                Position = player.Position,
                                JerseyNumber = tp.JerseyNumber
                            }
                            : null;
                    })
                    .Where(pd => pd != null)
                    .ToList();

                // Load game schedule
                ScheduleDetails = _repository.FetchGameSchedule(teamName, year).ToList();

                UpdateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Clear all data
        private void ClearData()
        {
            PlayerDetails.Clear();
            ScheduleDetails.Clear();
            UpdateData();
        }

        // Update the UI with new data
        private void UpdateData()
        {
            DataContext = null; // Force UI refresh
            DataContext = this;
        }

        // Handle changes to team or year selection
        private void OnTeamOrYearChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamComboBox.SelectedItem is string teamName && YearComboBox.SelectedItem is int year)
            {
                LoadData(teamName, year);
            }
            else
            {
                ClearData();
            }
        }

        // Navigate back to the home page
        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            CustomChange?.Invoke(this, new RoutedEventArgs());
        }

        // Navigate to the Add Player page
        private void NavigateToAddPlayer(object sender, RoutedEventArgs e)
        {
            AddPlayer?.Invoke(this, EventArgs.Empty);
        }
    }

    // Class to hold player details for display
    public class PlayerDetails
    {
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
    }
}
