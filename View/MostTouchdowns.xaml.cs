using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using PersonData;
using PersonData.Models;

namespace View
{
    /// <summary>
    /// Interaction logic for MostTouchdowns.xaml
    /// </summary>
    public partial class MostTouchdowns : UserControl
    {
        public event EventHandler<RoutedEventArgs>? CustomChange;

        private readonly SqlTouchDownRepository _touchdownRepository;
        private readonly ISelect _repository;

        public MostTouchdowns()
        {
            InitializeComponent();
            const string connectionString = @"Server=(localdb)\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;";
            _touchdownRepository = new SqlTouchDownRepository(connectionString);
            _repository = new SqlSelectRepository(connectionString);
            InitializeComboBoxes();
        }

        private void FetchRankings_Click(object sender, RoutedEventArgs e)
        {
            // Get selected year and position from the combo boxes
            if (YearComboBox.SelectedItem is int selectedYear && PositionComboBox.SelectedItem is string selectedPosition)
            {
                try
                {
                    // Fetch ranking data
                    List<PlayerTouchdownRank> ranking = _touchdownRepository.FetchTouchdownsRank(selectedYear, selectedPosition);

                    // Bind the fetched data to the DataGrid
                    touchdownDataGrid.ItemsSource = ranking;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching touchdown rankings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select both a year and a position.");
            }
            LoadYears();

        }

        private void InitializeComboBoxes()
        {
            LoadYears();

            // Hardcoded positions (can be changed to dynamic if needed)
            PositionComboBox.ItemsSource = new List<string>
            {
                "Quarterback", "Running Back", "Wide Receiver", "Tight End", "Defensive Back"
            };
            PositionComboBox.SelectedIndex = 0; // Default selection
        }

        private void LoadYears()
        {
            try
            {
                // Fetch years from repository
                var seasons = _repository.GetSeasons();
                YearComboBox.ItemsSource = seasons.Select(season => season.Year).ToList();
                YearComboBox.SelectedIndex = 0; // Default selection
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading years: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            CustomChange?.Invoke(this, new RoutedEventArgs());
        }
    }
}
