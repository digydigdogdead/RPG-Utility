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
using RPGUtility.Controls;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for StatTracker.xaml
    /// </summary>
    public partial class StatTracker : Page
    {
        public StatTracker()
        {
            InitializeComponent();
            ((App)Application.Current).StatTrackerPage = this;
        }

        private void clearStatsButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Stats = [];
            PopulateWrapPanel();
        }

        private void addStatButton_Click(object sender, RoutedEventArgs e)
        {
            StatTrack newStat = new StatTrack
            {
                Stat = statNameTextBox.Text,
                Value = (int)statValueIntegerUpDown.Value!
            };
            (App.Current as App)!.Stats.Add(newStat);
            (App.Current as App)!.Stats = new List<StatTrack>((App.Current as App)!.Stats);
            PopulateWrapPanel();
            statNameTextBox.Text = string.Empty;
            statValueIntegerUpDown.Value = 1;
            (App.Current as App)!.Stats = new((App.Current as App)!.Stats);
        }

        public void PopulateWrapPanel()
        {
            statsWrapPanel.Children.Clear();
            foreach (StatTrack stat in (App.Current as App)!.Stats)
            {
                statsWrapPanel.Children.Add(stat);
            }
        }
    }
}
