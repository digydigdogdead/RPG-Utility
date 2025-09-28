using System;
using System.Collections.Generic;
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
            nameof(Conditions), typeof(List<string>), typeof(Combatant), new PropertyMetadata(new List<string>(), OnConditionsChanged()));
        public List<string> Conditions
        {
            get { return (List<string>)GetValue(ConditionsProperty); }
            set { SetValue(ConditionsProperty, value); }
        }
        public Combatant()
        {
            InitializeComponent();
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
            };
        }

        private static PropertyChangedCallback OnCombatantNameChanged()
        {
            return (d, e) =>
            {
                Combatant combatant = (d as Combatant)!;
                combatant.nameTextBlock.Text = combatant.CombatantName;
            };
        }
        private static PropertyChangedCallback OnHpChanged()
        {
            return (d, e) =>
            {
                Combatant combatant = (d as Combatant)!;
                combatant.hpIntegerUpDown.Value = combatant.Hp;
            };
        }
        private static PropertyChangedCallback OnConditionsChanged()
        {
            return (d, e) =>
            {
                Combatant combatant = (d as Combatant)!;
                foreach (var condition in combatant.Conditions)
                {
                    TextBlock conditionText = new TextBlock()
                    {
                        Text = condition,
                        Padding = new Thickness(4),
                        FontSize = 12,
                        FontWeight = FontWeights.Bold
                    };
                    combatant.conditionsWrapPanel.Children.Add(conditionText);
                }
            };
        }

        private void initiativeIntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Initiative = (int)initiativeIntegerUpDown.Value!;
            (App.Current as App)!.InitiativeTrackerPage?.UpdateTracker();
        }
    }
}
