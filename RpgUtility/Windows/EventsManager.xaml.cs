using RPGUtility.Controls;
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
using System.Windows.Shapes;

namespace RPGUtility.Windows
{
    /// <summary>
    /// Interaction logic for EventsManager.xaml
    /// </summary>
    public partial class EventsManager : Window
    {
        public Day? Day { get; set; } = null;
        public EventsManager()
        {
            InitializeComponent();
        }

        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void removeEventButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
