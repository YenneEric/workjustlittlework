using PersonData;
using PersonData.Models;
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

namespace View
{
    /// <summary>
    /// Interaction logic for MostTouchdowns.xaml
    /// </summary>
    public partial class MostTouchdowns : UserControl
    {
        public event EventHandler<RoutedEventArgs>? CustomChange;

        private readonly SqlTouchDownRepository _touchdownRepository;

        

        public MostTouchdowns()
        {
            InitializeComponent();
            _touchdownRepository = new SqlTouchDownRepository("Server=(localdb)\\MSSQLLocalDb;Database=tuesday;Integrated Security=SSPI;");
            InitializeComboBoxes();
        }


        private void FetchRankings_Click(object sender, RoutedEventArgs e)
        {
            // Get selected year and position from the combo boxes
            int? selectedYear = YearComboBox.SelectedItem as int?;
            string? selectedPosition = PositionComboBox.SelectedItem as string;

            if (selectedYear.HasValue && !string.IsNullOrEmpty(selectedPosition))
            {
                // Fetch ranking data
                List<PlayerTouchdownRank> ranking = _touchdownRepository.FetchTouchdownsRank(selectedYear.Value, selectedPosition);

                // Bind the fetched data to the DataGrid
                touchdownDataGrid.ItemsSource = ranking;
            }
            else
            {
                MessageBox.Show("Please select both a year and a position.");
            }
        }

        private void InitializeComboBoxes()
        {
            YearComboBox.ItemsSource = new List<int> {2019, 2020, 2021, 2022, 2023, 2024 };
            YearComboBox.SelectedIndex = 0;  // Set default selection

            PositionComboBox.ItemsSource = new List<string> { "Quarterback", "Running Back", "Wide Receiver", "Tight End", "Defensive Back" };
            PositionComboBox.SelectedIndex = 0;  // Set default selection
        }




        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            CustomChange?.Invoke(this, new RoutedEventArgs());
        }
    }
}
