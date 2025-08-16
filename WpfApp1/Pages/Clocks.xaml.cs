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
            StackPanel newClockPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(5)
            };
            newClockPanel.Children.Add(new TextBlock
            {
                Text = clockNameTextBox.Text
            });
            Controls.Clock newClock = new Controls.Clock
            {
                Segments = (int)segmentsIntegerUpDown.Value!,
                DefaultColor = Colors.LightGray,
                FilledColor = Colors.ForestGreen,
                SquareSize = 70
            };
            newClockPanel.Children.Add(newClock);
            clocksStackPanel.Children.Add(newClockPanel);

        }

        private void clearClocksButton_Click(object sender, RoutedEventArgs e)
        {
            clocksStackPanel.Children.Clear();
        }
    }
}
