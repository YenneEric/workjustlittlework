using System;
using System.Windows;
using System.Windows.Controls;

namespace View
{
    public partial class EditPlayer : Page
    {
        public event EventHandler? NavigateBack;

        public EditPlayer()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateBack?.Invoke(this, EventArgs.Empty);
        }
    }
}
