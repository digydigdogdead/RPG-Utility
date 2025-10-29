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
using RPGUtility.Controls;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for InitiativeTracker.xaml
    /// </summary>
    public partial class InitiativeTracker : Page
    {
        public int CurrentTurnIndex { get; set; } = 0;
        public InitiativeTracker()
        {
            InitializeComponent();
            (App.Current as App)!.InitiativeTrackerPage = this;
        }

        private void addCombatantButton_Click(object sender, RoutedEventArgs e)
        {
            Combatant combatant = new Combatant()
            {
                CombatantName = nameTextBox.Text,
                Initiative = initiativeIntegerUpDown.Value ?? 1,
                Hp = HpIntegerUpDown.Value ?? 1
            };
            (App.Current as App)!.Combatants.Add(combatant);
            nameTextBox.Text = string.Empty;
            UpdateTracker();
        }
        

        private void previousTurnButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTurnIndex - 1 < 0)
            {
                CurrentTurnIndex = (App.Current as App)!.Combatants.Count - 1;
            } else
            {
                CurrentTurnIndex--;
            }
            UpdateTracker();
        }

        private void nextTurnButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTurnIndex + 1 >= (App.Current as App)!.Combatants.Count)
            {
                CurrentTurnIndex = 0;
            } else
            {
                CurrentTurnIndex++;
            }
            UpdateTracker();
        }

        public void UpdateTracker()
        {
            initiativeTrackPanel.Children.Clear();
            var initiativeList = ((App.Current as App)!.Combatants.OrderByDescending(c => c.Initiative)).ToList();

            for (int i = 0; i < initiativeList.Count(); i++)
            {
                if (i == CurrentTurnIndex)
                {
                    initiativeList[i].Background = new SolidColorBrush(Colors.LightGreen);
                }
                else initiativeList[i].Background = new SolidColorBrush(Colors.LightGray);

                initiativeTrackPanel.Children.Add(initiativeList[i]);
            }
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("""
                
                This page allows you to track combatants' initiatives during RPG encounters.
                To add a combatant, enter their name, initiative score, and hit points, then click "+".
                The program will automatically sort them in descending order based on initiative.
                Use the "Previous Turn" and "Next Turn" buttons in the bottom-right corner to navigate through the combatants' turns.
                The current turn is highlighted in green.
                You can edit a combatant's HP directly in the tracker by clicking on their HP value, and remove them by clicking the "X" button next to their name.
                
                """, "Initiative Tracker Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
