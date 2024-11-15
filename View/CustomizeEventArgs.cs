using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace View
{
    public class CustomizeEventArgs : RoutedEventArgs
    {
        public string Name { get; }

        public CustomizeEventArgs(string name)
        {
            Name = name;
        }

    }
}
