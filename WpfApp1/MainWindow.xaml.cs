using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPGUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            presetComboBox.SelectedItem = defaultCbi;
        }

        public void updateListView()
        {
            logListView.Items.Clear();
            foreach (string roll in (App.Current as App)!.RollHistory)
            {
                logListView.Items.Add(roll);
            }
        }

        private void presetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (presetComboBox.SelectedItem == defaultCbi)
            {
                rollerPresetFrame.Source = new Uri("Pages/DiceRollerPresets/DiceRollerTab.xaml", UriKind.Relative);
            }
            else if (presetComboBox.SelectedItem == wilderfeastCbi)
            {
                rollerPresetFrame.Source = new Uri("Pages/DiceRollerPresets/WiderFeastDiceRoller.xaml", UriKind.Relative);
            }
        }
    }
}