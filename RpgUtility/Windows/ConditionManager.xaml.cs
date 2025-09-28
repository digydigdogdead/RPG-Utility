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
        private Combatant? _combatant;
        public Combatant? Combatant
        {
            get { return _combatant; }
            set
            {
                _combatant = value;
                if (_combatant != null)
                {
                    titleTextBlock.Text = _combatant.CombatantName + " Conditions";
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

        }

        private void removeConditionButton_Click(object sender, RoutedEventArgs e)
        {

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

        }
    }
}
