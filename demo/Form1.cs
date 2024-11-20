using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PersonData; // Namespace containing repositories and models
using PersonData.Models;

namespace demo
{
    public partial class Form1 : Form
    {
        private readonly ISelect _repository;

        public Form1()
        {
            InitializeComponent();

            // Initialize the repository with a connection string
            const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
            _repository = new SqlSelectRepository(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Fetch team data for "Kansas State Wildcats"
                var team = _repository.GetTeams(teamName: "Kansas State Wildcats").FirstOrDefault();
                if (team == null)
                {
                    MessageBox.Show("Team 'Kansas State Wildcats' not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Fetch season data for the year 2019
                var season = _repository.GetSeasons(year: 2019).FirstOrDefault();
                if (season == null)
                {
                    MessageBox.Show("Season for the year 2019 not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Fetch players for the team and season
                var teamPlayers = _repository.GetTeamPlayers(teamId: team.TeamId, seasonId: season.SeasonId);
                if (teamPlayers.Count == 0)
                {
                    MessageBox.Show("No players found for 'Kansas State Wildcats' in 2019.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Fetch player details and display in the ListBox
                var players = new List<string>();
                foreach (var teamPlayer in teamPlayers)
                {
                    var player = _repository.GetPlayers(playerId: teamPlayer.PlayerId).FirstOrDefault();
                    if (player != null)
                    {
                        players.Add($"{player.PlayerName} ({player.Position})");
                    }
                }

                if (players.Count > 0)
                {
                    box2.DataSource = players; // Bind the list of player names and positions
                }
                else
                {
                    MessageBox.Show("No player details found for the selected team and season.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxAddressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection change
            if (box.SelectedItem is string selectedAddressType)
            {
                MessageBox.Show($"Selected Address Type: {selectedAddressType}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
