using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PersonData;
using PersonData.Models;


namespace View
{
    /// <summary>
    /// Interaction logic for TopScoring.xaml
    /// </summary>
    public partial class TopScoring : UserControl
    {
        public event EventHandler<RoutedEventArgs>? CustomChange;

        private readonly SqlTopScoringTeam _topScoringRepository;
        public TopScoring()
        {
            InitializeComponent();
            _topScoringRepository = new SqlTopScoringTeam("Server=(localdb)\\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;");
            InitializeComboBoxes();
        }

        private void FetchTopScoringTeams_Click(object sender, RoutedEventArgs e)
        {
            // Get selected year from the combo box
            int? selectedYear = YearComboBox.SelectedItem as int?;

            if (selectedYear.HasValue)
            {
                // Fetch top scoring teams
                try
                {
                    List<TopScoringTeamRank> topScoringTeams = _topScoringRepository.FetchTopScoringTeams(selectedYear.Value);

                    // Bind the fetched data to the DataGrid
                    topScoringTeamsDataGrid.ItemsSource = topScoringTeams;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while fetching top-scoring teams: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid year.");
            }
        }

        private void InitializeComboBoxes()
        {
            YearComboBox.ItemsSource = new List<int> { 2019, 2020, 2021, 2022, 2023, 2024 };
            YearComboBox.SelectedIndex = 0;  // Set default selection
        }


        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            CustomChange?.Invoke(this, new RoutedEventArgs());
        }
    }
}
