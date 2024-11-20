using System;
using System.Windows;
using System.Windows.Controls;
using PersonData;

namespace View
{
    /// <summary>
    /// Interaction logic for AddGame.xaml
    /// </summary>
    public partial class AddGame : Page
    {
        private readonly IInsert _insertRepository;

        public AddGame()
        {
            InitializeComponent();

            // Initialize repository
            const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
            _insertRepository = new SqlInsertRepository(connectionString);
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var gameDate = GameDatePicker.SelectedDate;
                var location = LocationTextBox.Text;
                var isCanceled = CanceledCheckBox.IsChecked == true ? 1 : 0;

                if (gameDate == null || string.IsNullOrWhiteSpace(location))
                {
                    MessageBox.Show("Please provide all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _insertRepository.CreateGame(gameDate.Value, location, isCanceled);

                MessageBox.Show("Game added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding game: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackToInsertData(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Content = new InsertData();
            }
        }
    }
}
