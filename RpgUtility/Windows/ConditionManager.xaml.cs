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
    /// Interaction logic for ConditionManager.xaml
    /// </summary>
    public partial class ConditionManager : Window
    {
        public Combatant? Combatant
        {
            get;
            set
            {
                field = value;
                if (field != null)
                {
                    titleTextBlock.Text = field.CombatantName + " Conditions";
                    UpdateList();
                }
            }
        }
        public ConditionManager()
        {
            InitializeComponent();
        }

        private void addConditionButton_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem item = new();
            item.Content = conditionTextBox.Text;
            conditionsListView.Items.Add(item);
            conditionTextBox.Text = string.Empty;
        }

        private void removeConditionButton_Click(object sender, RoutedEventArgs e)
        {
            conditionsListView.Items.Remove(conditionsListView.SelectedItem);
        }

        public void UpdateList()
        {
            foreach (var condition in Combatant!.Conditions)
            {
                ListViewItem item = new();
                item.Content = condition;
                conditionsListView.Items.Add(item);
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Combatant!.Conditions.Clear();
            foreach (ListViewItem item in conditionsListView.Items)
            {
                Combatant!.Conditions.Add(item.Content.ToString()!);
            }
            Combatant.UpdateConditionsText();
            (App.Current as App)!.InitiativeTrackerPage?.UpdateTracker();
            (App.Current as App)!.Combatants = new((App.Current as App)!.Combatants);
            this.Close();
        }

        private void conditionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                addConditionButton_Click(this, new RoutedEventArgs());
            }
        }
    }
}
