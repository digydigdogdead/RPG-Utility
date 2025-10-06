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
using RPGUtility.Controls;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        public Controls.Calendar currentCalendar { get; set; } = new Controls.Calendar();
        public CalendarPage()
        {
            InitializeComponent();
            (App.Current as App)!.CalendarPage = this;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
