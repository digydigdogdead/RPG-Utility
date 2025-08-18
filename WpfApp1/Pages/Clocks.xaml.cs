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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for Clocks.xaml
    /// </summary>
    public partial class Clocks : Page
    {
        public Clocks()
        {
            InitializeComponent();
        }

        private void addClockButton_Click(object sender, RoutedEventArgs e)
        {
            Controls.Clock newClock = new Controls.Clock
            {
                Segments = (int)segmentsIntegerUpDown.Value!,
                DefaultColor = Colors.LightGray,
                FilledColor = Colors.ForestGreen,
                SquareSize = 70,
                ClockName = clockNameTextBox.Text
            };
            (App.Current as App)!.Clocks.Add(newClock);
            clockNameTextBox.Clear();
            segmentsIntegerUpDown.Value = 4; // Reset to default value
            UpdateClockStack();

        }

        private void clearClocksButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Clocks.Clear();
            UpdateClockStack();
        }

        private void UpdateClockStack()
        {
            clocksStackPanel.Children.Clear();
            foreach (var clock in (App.Current as App)!.Clocks)
            {
                clocksStackPanel.Children.Add(clock);
            }
        }
    }
}
