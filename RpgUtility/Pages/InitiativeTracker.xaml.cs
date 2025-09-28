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
            (App.Current as App)!.Combatants = (App.Current as App)!.Combatants.OrderByDescending(c => c.Initiative).ToList();

            for (int i = 0; i < (App.Current as App)!.Combatants.Count; i++)
            {
                if (i == CurrentTurnIndex)
                {
                    (App.Current as App)!.Combatants[i].Background = new SolidColorBrush(Colors.LightGreen);
                }
                else (App.Current as App)!.Combatants[i].Background = new SolidColorBrush(Colors.LightGray);

                initiativeTrackPanel.Children.Add((App.Current as App)!.Combatants[i]);
            }

            /*
            combatantsListView.Items.Clear();
            (App.Current as App)!.Combatants = (App.Current as App)!.Combatants.OrderByDescending(c => c.Initiative).ToList();

            for (int i = 0; i < (App.Current as App)!.Combatants.Count; i++)
            {
                (App.Current as App)!.Combatants[i].TurnOrder = i + 1;
                ListViewItem item = new ListViewItem();
                item.Content = (App.Current as App)!.Combatants[i];
                item.BorderBrush = new SolidColorBrush(Colors.Black);
                item.BorderThickness = new Thickness(0, 0, 1, 1);
                item.FontSize = 16;
                if (i == CurrentTurnIndex)
                {
                    item.Background = new SolidColorBrush(Colors.LightGreen);
                } else
                {
                    item.Background = new SolidColorBrush(Colors.White);
                }
                combatantsListView.Items.Add(item);
            } */
        }

        /*
        private void combatantsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ListViewItem item in combatantsListView.Items)
            {
                if (item == combatantsListView.SelectedItem)
                {
                    item.Background = new SolidColorBrush(Colors.LightGray);
                }
                else if (item == combatantsListView.Items[CurrentTurnIndex])
                {
                    item.Background = new SolidColorBrush(Colors.LightGreen);
                }
                else 
                {
                    item.Background = new SolidColorBrush(Colors.White);
                }
            }
        }
        */
    }
}
