using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RPGUtility.Controls
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public static readonly DependencyProperty CurrentYearProperty = DependencyProperty.Register(
            nameof(CurrentYear), typeof(int), typeof(Calendar), new PropertyMetadata(1000, OnYearChanged()));
        public int CurrentYear 
        {
            get { return (int)GetValue(CurrentYearProperty); }
            set { SetValue(CurrentYearProperty, value); }
        }
        public static readonly DependencyProperty CurrentMonthIndexProperty = DependencyProperty.Register(
            nameof(CurrentMonthIndex), typeof(int), typeof(Calendar), new PropertyMetadata(1, OnMonthChanged()));
        public int CurrentMonthIndex 
        {
            get { return (int)GetValue(CurrentMonthIndexProperty); }
            set { SetValue(CurrentMonthIndexProperty, value); }
        }

        public Dictionary<string, int> MonthsToDays { get; set; } = new Dictionary<string, int>();

        public Calendar()
        {
            InitializeComponent();
        }

        private void PrevMonthButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonthIndex == 0)
            {
                CurrentYear--;
                CurrentMonthIndex = MonthsToDays.Count - 1;
                return;
            }
            CurrentMonthIndex--;
        }

        private void NextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonthIndex == MonthsToDays.Count - 1)
            {
                CurrentYear++;
                CurrentMonthIndex = 0;
                return;
            }
            CurrentMonthIndex++;
        }

        private static PropertyChangedCallback OnYearChanged()
        {
            return (d, e) =>
            {
                if (d is Calendar calendar)
                {
                    calendar.YearText.Text = calendar.CurrentYear.ToString();
                    calendar.PopulateCalendar();
                }
            };
        }

        private static PropertyChangedCallback OnMonthChanged()
        {
            return (d, e) =>
            {
                if (d is Calendar calendar)
                {
                    calendar.MonthText.Text = calendar.MonthsToDays.ElementAt(calendar.CurrentMonthIndex).Key;
                    calendar.PopulateCalendar();
                }
            };
        }

        public void PopulateCalendar()
        {
            DaysPanel.Children.Clear();
           var daysInMonth = (from day in (App.Current as App)!.DaysInCalendar
                             where day.Month == MonthsToDays.ElementAt(CurrentMonthIndex).Key
                             && day.Year == CurrentYear
                             select day).ToList();

            if (daysInMonth.Count == 0)
            {
                for (int i = 1; i <= MonthsToDays.ElementAt(CurrentMonthIndex).Value; i++)
                {
                    (App.Current as App)!.DaysInCalendar.Add(new Day() { DayNumber = i, Month = MonthsToDays.ElementAt(CurrentMonthIndex).Key, Year = CurrentYear });
                }
            }

            foreach (var day in daysInMonth)
            {
                DaysPanel.Children.Add(day);
            }
        }
    }
}
