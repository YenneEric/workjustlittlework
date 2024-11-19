using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using PersonData; // Assuming this namespace contains IAddressRepository and SqlAddressRepository.

namespace demo

{
    public partial class Form1 : Form
    {
        private readonly IAddressRepository addressRepository;
        private readonly IStatRepository stats;

        public Form1()
        {
            InitializeComponent();

            // Initialize the address repository with a connection string.
            // Replace with your actual database connection string.
            const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
            addressRepository = new SqlAddressRepository(connectionString);
            stats = new SqlTouchDownRepository(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Load address type names into comboBoxAddressType
                var addressTypeNames = addressRepository.GetAddressName();
                if (addressTypeNames != null && addressTypeNames.Count > 0)
                {
                    box.DataSource = addressTypeNames;
                }
                else
                {
                    MessageBox.Show("No address types available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Fetch touchdowns
                var touchdowns = stats.FetchTouchdownPlayer("Quarterback", 2019);
                if (touchdowns != null && touchdowns.Count > 0)
                {
                    // Extract player names and bind them to box2
                    var playerNames = new List<string>();
                    foreach (var stat in touchdowns)
                    {
                        playerNames.Add(stat.Player.PlayerName); // Get PlayerName from each PlayerTouchdownStats
                    }

                    box2.DataSource = playerNames; // Bind the list of player names
                }
                else
                {
                    MessageBox.Show("No touchdowns found for the given position and year.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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