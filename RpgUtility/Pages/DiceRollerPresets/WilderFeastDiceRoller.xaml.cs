using System.Windows;
using System.Windows.Controls;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for WiderFeastDiceRoller.xaml
    /// </summary>
    public partial class WiderFeastDiceRoller : Page
    {
        public WiderFeastDiceRoller()
        {
            InitializeComponent();
        }

        private void rollButton_Click(object sender, RoutedEventArgs e)
        {
            int successes = 0;
            int[] styleRolls = new int[(int)styleDiceUpDown.Value!];
            int actionRoll = 0;

            for (int i = 0; i < styleDiceUpDown.Value; i++)
            {
                int roll = new Random().Next(1, 7); // Simulate a dice roll (1-6)
                styleRolls[i] = roll; // Store the roll in the array
                if (advComboBox.SelectedItem == normalCbi && roll >= 5) // 5 or 6 is a success
                {
                    successes++;
                }
                else if (advComboBox.SelectedItem == advantageCbi && roll >= 4) // 4, 5, or 6 is a success
                {
                    successes++;
                }
                else if (advComboBox.SelectedItem == disadvantageCbi && roll == 6) // Only 6 is a success
                {
                    successes++;
                }
            }

            if (actionDieComboBox.SelectedItem == focusUpCbi)
            {
                actionRoll = new Random().Next(1, 9);
            }
            else if (actionDieComboBox.SelectedItem == goWildCbi)
            {
                actionRoll = new Random().Next(1, 21);
            }

            (App.Current as App)!.RollHistory.Push($"{successes} Successes ({String.Join(',', styleRolls)}), [A] = {actionRoll}");
            ((MainWindow)System.Windows.Application.Current.MainWindow).updateListView();
        }
    }
}
