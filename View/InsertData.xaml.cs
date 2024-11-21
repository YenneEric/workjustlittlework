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

        public event EventHandler? AddGame;
        public event EventHandler? EditPlayer;

        public PlayerDetails? SelectedPlayer { get; set; } // Tracks the selected player

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
            ClearData();
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
                                PlayerId = player.PlayerId,
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
            DataContext = null;
            DataContext = this;
        }

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

        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            CustomChange?.Invoke(this, new RoutedEventArgs());
        }

        private void NavigateToAddPlayer(object sender, RoutedEventArgs e)
        {
            AddPlayer?.Invoke(this, EventArgs.Empty);
        }

        private void NavigateToAddGame(object sender, RoutedEventArgs e)
        {
            AddGame?.Invoke(this, EventArgs.Empty);
        }

        private void NavigateToEditPlayer(object sender, RoutedEventArgs e)
        {
            if (SelectedPlayer == null)
            {
                MessageBox.Show("Please select a player to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            EditPlayer?.Invoke(this, EventArgs.Empty);
        }
    }

    public class PlayerDetails
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
    }
}
