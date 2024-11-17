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
                // Load address type names
                var addressTypeNames = addressRepository.GetAddressName();
                box.DataSource = addressTypeNames;

                // Fetch touchdowns
                var touchdowns = stats.FetchTouchdownPlayer("Quarterback", 2019);

                // Bind touchdowns to box2
                box2.DataSource = touchdowns;
                box2.DisplayMember = "PlayerName"; // Display PlayerName in the list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void comboBoxAddressType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection change
            var selectedAddressType = box.SelectedItem as string;
            if (selectedAddressType != null)
            {
                MessageBox.Show($"Selected Address Type: {selectedAddressType}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
