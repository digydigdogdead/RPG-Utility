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
    /// Interaction logic for CalendarEditor.xaml
    /// </summary>
    public partial class CalendarEditor : Window
    {
        public CalendarEditor()
        {
            InitializeComponent();
        }

        private void AddMonthButton_Click(object sender, RoutedEventArgs e)
        {
            string monthName = MonthNameTextBox.Text;
            int daysInMonth = (int)DaysInMonthIntegerUpDown.Value!;
            var month = new { MonthName = monthName, DaysInMonth = daysInMonth };
            MonthsListView.Items.Add(month);
        }

        private void RemoveMonthButton_Click(object sender, RoutedEventArgs e)
        {
            MonthsListView.Items.Remove(MonthsListView.SelectedItem);
        }

        private void UseGregorianButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MonthsListView.Items)
            {
                var month = (dynamic)item;
                (App.Current as App)!.MonthsToDays[month.MonthName] = month.DaysInMonth;
            }
            (App.Current as App)!.CurrentYear = (int)CurrentYearIntegerUpDown.Value!;
            (App.Current as App)!.CurrentMonthIndex = 0;
            (App.Current as App)!.CalendarPage!.currentCalendar!.PopulateCalendar();
            this.Close();
        }
    }
}
