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

        public Form1()
        {
            InitializeComponent();

            // Initialize the address repository with a connection string.
            // Replace with your actual database connection string.
            const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=temp;Integrated Security=SSPI;";
            addressRepository = new SqlAddressRepository(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var addressTypeNames = addressRepository.GetAddressName();

                box.DataSource = addressTypeNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"HERE?Error loading Address Types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
