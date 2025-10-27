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

        public Calendar()
        {
            InitializeComponent();
        }

        private void PrevMonthButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonthIndex == 0)
            {
                (App.Current as App)!.CurrentYear--;
                (App.Current as App)!.CurrentMonthIndex = (App.Current as App)!.MonthsToDays.Count - 1;
                PopulateCalendar();
                return;
            }
            (App.Current as App)!.CurrentMonthIndex--;
            PopulateCalendar();
        }

        private void NextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMonthIndex == (App.Current as App)!.MonthsToDays.Count - 1)
            {
                (App.Current as App)!.CurrentYear++;
                (App.Current as App)!.CurrentMonthIndex = 0;
                PopulateCalendar();
                return;
            }
            (App.Current as App)!.CurrentMonthIndex++;
            PopulateCalendar();
        }

        private static PropertyChangedCallback OnYearChanged()
        {
            return (d, e) =>
            {
                if (d is Calendar calendar)
                {
                    calendar.YearText.Text = calendar.CurrentYear.ToString();
                }
            };
        }

        private static PropertyChangedCallback OnMonthChanged()
        {
            return (d, e) =>
            {
                if (d is Calendar calendar)
                {
                    calendar.MonthText.Text = (App.Current as App)!.MonthsToDays.ElementAt(calendar.CurrentMonthIndex).Key;
                }
            };
        }

        public void PopulateCalendar()
        { 
           var daysInMonth = (from day in (App.Current as App)!.DaysInCalendar
                             where day.Month == (App.Current as App)!.MonthsToDays.ElementAt(CurrentMonthIndex).Key
                             && day.Year == CurrentYear
                             select day).ToList();

            if (daysInMonth.Count < (App.Current as App)!.MonthsToDays.ElementAt(CurrentMonthIndex).Value)
            {
                for (int i = daysInMonth.Count + 1; i <= (App.Current as App)!.MonthsToDays.ElementAt(CurrentMonthIndex).Value; i++)
                {
                    if (!(App.Current as App)!.DaysInCalendar.Any(d => d.DayNumber == i
                                                            && d.Month == (App.Current as App)!.MonthsToDays.ElementAt(CurrentMonthIndex).Key
                                                            && d.Year == CurrentYear))
                    {
                        (App.Current as App)!.DaysInCalendar.Add(new Day()
                        {
                            DayNumber = i,
                            Month = (App.Current as App)!.MonthsToDays.ElementAt(CurrentMonthIndex).Key,
                            Year = CurrentYear
                        });
                    }
                }
            }

            DaysPanel.Children.Clear();

            YearText.Text = CurrentYear.ToString();
            foreach (var day in daysInMonth)
            {
                DaysPanel.Children.Add(day);
            }
        }

        private void AddDayMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if ((App.Current as App)!.DaysInCalendar == null || (App.Current as App)!.DaysInCalendar.Count == 0) 
            {
                return;
            }
            var currentMonth = from days in (App.Current as App)!.DaysInCalendar
                               where days.Month == (App.Current as App)!.MonthsToDays.ElementAt(CurrentMonthIndex).Key
                               && days.Year == CurrentYear
                               select days;
            int nextDayNumber = currentMonth.Count() + 1;
            (App.Current as App)!.DaysInCalendar.Add(new Day()
            {
                DayNumber = nextDayNumber,
                Month = (App.Current as App)!.MonthsToDays.ElementAt(CurrentMonthIndex).Key,
                Year = CurrentYear
            });
            PopulateCalendar();
        }
    }
}
