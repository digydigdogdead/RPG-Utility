using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
    /// Interaction logic for Day.xaml
    /// </summary>
    public partial class Day : UserControl
    {
        public static readonly DependencyProperty EventsProperty = DependencyProperty.Register(
            nameof(Events), typeof(ObservableCollection<string>), typeof(Day), new PropertyMetadata(null, OnEventsChanged()));
        public ObservableCollection<string> Events
        {
            get { return (ObservableCollection<string>)GetValue(EventsProperty); }
            set { SetValue(EventsProperty, value); }
        }

        public static readonly DependencyProperty DayNumberProperty = DependencyProperty.Register(
            nameof(DayNumber), typeof(int), typeof(Day), new PropertyMetadata(1, OnDayNumberChanged()));
        public int DayNumber
        {
            get { return (int)GetValue(DayNumberProperty); }
            set { SetValue(DayNumberProperty, value); }
        }

        public string Month { get; set; } = "Month";
        public int Year { get; set; } = 1000;
        public Day()
        {
            InitializeComponent();
            Events = new ObservableCollection<string>();
            Events.CollectionChanged += (s, e) => UpdateEventsText();
            UpdateEventsText();
            DayNumberText.Text = DayNumber.ToString();
        }

        private static PropertyChangedCallback OnEventsChanged()
        {
            return (d, e) =>
            {
                if (d is Day day && day.Events != null)
                {
                    day.Events.CollectionChanged += (s, ev) => day.UpdateEventsText();
                    day.UpdateEventsText();
                }
            };
        }

        private void UpdateEventsText()
        {
            EventsPanel.Children.Clear();
            foreach (var evt in Events)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = evt,
                    Margin = new Thickness(2),
                    Padding = new Thickness(4),
                    Background = new SolidColorBrush(Colors.LightGray),
                    Foreground = new SolidColorBrush(Colors.Black),
                    FontSize = 12,
                    TextWrapping = TextWrapping.Wrap
                };
                EventsPanel.Children.Add(textBlock);
            }
        }

        private static PropertyChangedCallback OnDayNumberChanged()
        {
            return (d, e) =>
            {
                if (d is Day day)
                {
                    day.DayNumberText.Text = day.DayNumber.ToString();
                }
            };
        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            new Windows.EventsManager
            {
                Day = this
            }.ShowDialog();
        }

        private void ManageEventsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DoubleClick(sender, null!);
        }

        private void DeleteDayMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new Windows.DeleteDayConfirm
            {
                DayToDelete = this
            }.ShowDialog();
        }
    }
}
