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

namespace RPGUtility.Pages.DiceRollerPresets
{
    /// <summary>
    /// Interaction logic for HouseholdDiceRoller.xaml
    /// </summary>
    public partial class HouseholdDiceRoller : Page
    {
        public Dictionary<int, int> RollCounts = new Dictionary<int, int>()
        {
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0}
        };
        public HouseholdDiceRoller()
        {
            InitializeComponent();
        }

        private void rollButton_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int[] rolls = new int[(int)diceIntegerUpDown.Value!];

            for (int i = 0; i < diceIntegerUpDown.Value; i++)
            {
                rolls[i] = rand.Next(1, 7);
            }

            for (int i = 1; i < 7; i++)
            {
                RollCounts[i] = rolls.Where(num => num == i).Count();
            }

            DetermineAndPushSuccesses();
        }

        private void DetermineAndPushSuccesses()
        {
            Dictionary<string, int> successes = new Dictionary<string, int>()
            {
                {"Basic", 0 },
                {"Critical", 0},
                {"Extreme", 0 },
                {"Impossible", 0 },
                {"Jackpot", 0 }
            };

            string successMessage = string.Empty;

            foreach (var count in RollCounts)
            {
                if (count.Value == 2) successes["Basic"]++;
                if (count.Value == 3) successes["Critical"]++;
                if (count.Value == 4) successes["Extreme"]++;
                if (count.Value == 5) successes["Impossible"]++;
                if (count.Value == 6) successes["Jackpot"]++;
            }

            if (successes.All(kvp => kvp.Value == 0))
            {
                successMessage = "No successes. ";
            }
            else
            {

                foreach (var count in successes)
                {
                    if (count.Value != 0)
                    {
                        successMessage += $"{count.Value} {count.Key} successes, ";
                    }
                }
            }

            string rollMessage = "(";

            foreach (var count in RollCounts)
            {
                for (var i = 0; i < count.Value; i++)
                {
                    rollMessage += $"{count.Key}, ";
                }
            }

            rollMessage = rollMessage.TrimEnd([',',' ']);
            rollMessage += ')';

            (App.Current as App)!.RollHistory.Push(successMessage + rollMessage);
            ((MainWindow)System.Windows.Application.Current.MainWindow).updateListView();
        }
    }
}
