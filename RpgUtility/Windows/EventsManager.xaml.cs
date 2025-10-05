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
        public Day? Day 
        { 
            get { return _day; }
            set 
            {
                _day = value;
                titleTextBlock.Text = $"{_day?.DayNumber} of {_day?.Month}, {_day?.Year}";
                foreach (var evt in _day?.Events ?? Enumerable.Empty<string>())
                {
                    var eventItem = new ListViewItem()
                    {
                        Content = evt
                    };
                    eventsListView.Items.Add(eventItem);
                }
            }
        }
        private Day? _day = null;
        public EventsManager()
        {
            InitializeComponent();
        }

        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            var eventItem = new ListViewItem()
            {
                Content = eventTextBox.Text
            };
            eventsListView.Items.Add(eventItem);
        }

        private void removeEventButton_Click(object sender, RoutedEventArgs e)
        {
            eventsListView.Items.Remove(eventsListView.SelectedItem);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            _day?.Events.Clear();
            foreach (ListViewItem item in eventsListView.Items)
            {
                _day?.Events.Add(item.Content.ToString() ?? string.Empty);
            }
        }
    }
}
