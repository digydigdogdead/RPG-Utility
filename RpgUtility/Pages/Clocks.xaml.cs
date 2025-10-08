using System.Windows;
using System.Windows.Controls;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for Clocks.xaml
    /// </summary>
    public partial class Clocks : Page
    {
        public Clocks()
        {
            InitializeComponent();
            (App.Current as App)!.ClocksPage = this;
        }

        private void addClockButton_Click(object sender, RoutedEventArgs e)
        {
            Controls.Clock newClock = new Controls.Clock
            {
                Segments = (int)segmentsIntegerUpDown.Value!,
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

        public void UpdateClockStack()
        {
            clocksStackPanel.Children.Clear();
            foreach (var clock in (App.Current as App)!.Clocks)
            {
                clocksStackPanel.Children.Add(clock);
            }
        }
    }
}
