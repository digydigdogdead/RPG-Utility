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
    /// Interaction logic for AddToCalendarWindow.xaml
    /// </summary>
    public partial class AddToCalendarWindow : Window
    {
        public AddToCalendarWindow()
        {
            InitializeComponent();
            if ((App.Current as App)!.MonthsToDays.Count > 0)
            {
                foreach (var month in (App.Current as App)!.MonthsToDays)
                {
                    monthComboBox.Items.Add(month.Key);
                }
            }
        }

        private void addToCalendarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Day day;

                if ((App.Current as App)!.DaysInCalendar.Any(d => d.DayNumber == (int)dayUpDown.Value!
                                                            && d.Month == monthComboBox.SelectedItem.ToString()!
                                                            && d.Year == (int)yearUpDown.Value!))
                {
                    day = (App.Current as App)!.DaysInCalendar.First(d => d.DayNumber == (int)dayUpDown.Value!
                                                            && d.Month == monthComboBox.SelectedItem.ToString()!
                                                            && d.Year == (int)yearUpDown.Value!);
                }
                else
                {
                    day = new Day()
                    {
                        DayNumber = (int)dayUpDown.Value!,
                        Month = monthComboBox.SelectedItem.ToString()!,
                        Year = (int)yearUpDown.Value!,
                        Events = new System.Collections.ObjectModel.ObservableCollection<string>()
                    };
                    (App.Current as App)!.DaysInCalendar.Add(day);
                }

                day.Events.Add(eventTitleTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the event to the calendar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}
