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
            MonthNameTextBox.Clear();
        }

        private void RemoveMonthButton_Click(object sender, RoutedEventArgs e)
        {
            MonthsListView.Items.Remove(MonthsListView.SelectedItem);
        }

        private void UseGregorianButton_Click(object sender, RoutedEventArgs e)
        {
            var january = new { MonthName = "January", DaysInMonth = 31 };
            MonthsListView.Items.Add(january);
            var february = new { MonthName = "February", DaysInMonth = 28 };
            MonthsListView.Items.Add(february);
            var march = new { MonthName = "March", DaysInMonth = 31 };
            MonthsListView.Items.Add(march);
            var april = new { MonthName = "April", DaysInMonth = 30 };
            MonthsListView.Items.Add(april);
            var may = new { MonthName = "May", DaysInMonth = 31 };
            MonthsListView.Items.Add(may);
            var june = new { MonthName = "June", DaysInMonth = 30 };
            MonthsListView.Items.Add(june);
            var july = new { MonthName = "July", DaysInMonth = 31 };
            MonthsListView.Items.Add(july);
            var august = new { MonthName = "August", DaysInMonth = 31 };
            MonthsListView.Items.Add(august);
            var september = new { MonthName = "September", DaysInMonth = 30 };
            MonthsListView.Items.Add(september);
            var october = new { MonthName = "October", DaysInMonth = 31 };
            MonthsListView.Items.Add(october);
            var november = new { MonthName = "November", DaysInMonth = 30 };
            MonthsListView.Items.Add(november);
            var december = new { MonthName = "December", DaysInMonth = 31 };
            MonthsListView.Items.Add(december);
        }

        private void SaveCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            if (MonthsListView.Items.Count == 0) return;
            (App.Current as App)!.MonthsToDays.Clear();
            foreach (var item in MonthsListView.Items)
            {
                var month = (dynamic)item;
                (App.Current as App)!.MonthsToDays[month.MonthName] = month.DaysInMonth;
            }
            (App.Current as App)!.DaysInCalendar.Clear();
            (App.Current as App)!.CurrentYear = (int)CurrentYearIntegerUpDown.Value!;
            (App.Current as App)!.CurrentMonthIndex = 0;
            (App.Current as App)!.CalendarPage!.currentCalendar!.PopulateCalendar();
            this.Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MonthsListView.Items.Clear();
        }
    }
}
