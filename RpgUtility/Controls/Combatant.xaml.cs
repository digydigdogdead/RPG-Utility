using RPGUtility.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
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

namespace RPGUtility.Controls
{
    /// <summary>
    /// Interaction logic for Combatant.xaml
    /// </summary>
    public partial class Combatant : UserControl
    {
        public static readonly DependencyProperty InitiativeProperty = DependencyProperty.Register(
            nameof(Initiative), typeof(int), typeof(Combatant), new PropertyMetadata(1, OnInitiativeChanged()));
        public int Initiative
        {
            get { return (int)GetValue(InitiativeProperty); }
            set { SetValue(InitiativeProperty, value); }
        }
        public static readonly DependencyProperty CombatantNameProperty = DependencyProperty.Register(
            nameof(CombatantName), typeof(string), typeof(Combatant), new PropertyMetadata("Combatant", OnCombatantNameChanged()));
        public string CombatantName
        {
            get { return (string)GetValue(CombatantNameProperty); }
            set { SetValue(CombatantNameProperty, value); }
        }
        public static readonly DependencyProperty HpProperty = DependencyProperty.Register(
            nameof(Hp), typeof(int), typeof(Combatant), new PropertyMetadata(1, OnHpChanged()));
        public int Hp
        {
            get { return (int)GetValue(HpProperty); }
            set { SetValue(HpProperty, value); }
        }
        public static readonly DependencyProperty ConditionsProperty = DependencyProperty.Register(
            nameof(Conditions), typeof(ObservableCollection<string>), typeof(Combatant), new PropertyMetadata(null, OnConditionsChanged()));
        public ObservableCollection<string> Conditions
        {
            get { return (ObservableCollection<string>)GetValue(ConditionsProperty); }
            set { SetValue(ConditionsProperty, value); }
        }
        public Combatant()
        {
            InitializeComponent();
            Conditions = new ObservableCollection<string>();
            Conditions.CollectionChanged += (s, e) => UpdateConditionsText();
        }

        private void removeCombatantButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Combatants.Remove(this);
            (App.Current as App)!.InitiativeTrackerPage?.UpdateTracker();
        }

        private static PropertyChangedCallback OnInitiativeChanged()
        {
            return (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            {
                Combatant combatant = (d as Combatant)!;
                combatant.initiativeIntegerUpDown.Value = combatant.Initiative;
                (App.Current as App)!.ChangesMade();
            };
        }

        private static PropertyChangedCallback OnCombatantNameChanged()
        {
            return (d, e) =>
            {
                Combatant combatant = (d as Combatant)!;
                combatant.nameTextBlock.Text = combatant.CombatantName;
                (App.Current as App)!.ChangesMade();
            };
        }
        private static PropertyChangedCallback OnHpChanged()
        {
            return (d, e) =>
            {
                Combatant combatant = (d as Combatant)!;
                combatant.hpIntegerUpDown.Value = combatant.Hp;
                (App.Current as App)!.ChangesMade();
            };
        }
        private static PropertyChangedCallback OnConditionsChanged()
        {
            return (d, e) =>
            {
                Combatant combatant = (d as Combatant)!;
                combatant.UpdateConditionsText();
                (App.Current as App)!.ChangesMade();
            };
        }

        private void initiativeIntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Initiative = (int)initiativeIntegerUpDown.Value!;
            (App.Current as App)!.ChangesMade();
        }

        private void ConditionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.Tag is string condition)
            {
                if (!Conditions.Contains(condition))
                {
                    Conditions.Add(condition);
                }
                (App.Current as App)!.InitiativeTrackerPage?.UpdateTracker();
                (App.Current as App)!.ChangesMade();
            }
        }

        private void OpenConditionManager(object sender, RoutedEventArgs e)
        {
            ConditionManager conditionManager = new ConditionManager();
            conditionManager.Combatant = this;
            conditionManager.Show();
        }

        public void UpdateConditionsText()
        {
            conditionsWrapPanel.Children.Clear(); // Clear previous children
            foreach (var condition in Conditions)
            {
                TextBlock conditionText = new TextBlock()
                {
                    Text = condition,
                    Padding = new Thickness(4),
                    FontSize = 12,
                    FontWeight = FontWeights.Bold
                };
                conditionsWrapPanel.Children.Add(conditionText);
            }
        }

        private void hpIntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Hp = (int)hpIntegerUpDown.Value!;
            (App.Current as App)!.ChangesMade();
        }
    }
}
