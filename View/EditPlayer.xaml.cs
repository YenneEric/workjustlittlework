using System;
using System.Windows;
using System.Windows.Controls;
using PersonData;

namespace View
{
    public partial class EditPlayer : UserControl
    {
        public event EventHandler? NavigateBack;

        private readonly IUpdate _updateRepository;

        public EditPlayer()
        {
            InitializeComponent();

            // Initialize repository (replace with your connection string)
            const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
            _updateRepository = new SqlUpdateRepository(connectionString);
        }

        // Load player details into the fields
        public void LoadPlayerDetails(int playerId)
        {
            PlayerIdTextBox.Text = playerId.ToString();
        }

        // Save button click handler
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve the PlayerId value
                if (!int.TryParse(PlayerIdTextBox.Text, out var playerId))
                {
                    MessageBox.Show("Invalid Player ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var playerName = string.IsNullOrWhiteSpace(PlayerNameTextBox.Text) ? null : PlayerNameTextBox.Text;
                var position = (PositionComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

                // Call UpdatePlayer with PlayerId and optional parameters
                _updateRepository.UpdatePlayer(playerId, playerName, position);

                // Success message
                MessageBox.Show("Player updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Optionally, navigate back after save
                NavigateBack?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating player: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Back button click handler
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateBack?.Invoke(this, EventArgs.Empty);
        }
    }
}
