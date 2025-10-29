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
        public CalendarPage()
        {
            InitializeComponent();
            (App.Current as App)!.CalendarPage = this;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            new Windows.CalendarEditor().Show();
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("""
                
                This page allows you to manage your custom calendar for RPG campaigns. Click the settings wheel to open the calendar editor, where you can define months, days, and set the starting year.
                To use any calendar functions, a calendar must be defined first.
                Right-click on any day in the calendar view to add events or notes for that specific day.
                
                """, "Calendar Help", MessageBoxButton.OK, MessageBoxImage.Information);
                
        }
    }
}
