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
    /// Interaction logic for InsertData.xaml
    /// </summary>
    public partial class InsertData : UserControl
    {
        public event EventHandler<RoutedEventArgs>? CustomChange;
        public InsertData()
        {
            InitializeComponent();
        }

        private void BackToHomePage(object sender, RoutedEventArgs e)
        {
            CustomChange?.Invoke(this, new RoutedEventArgs());
        }
    }
}
