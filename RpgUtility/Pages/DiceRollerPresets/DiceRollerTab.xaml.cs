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
using System.Linq;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for DiceRollerTab.xaml
    /// </summary>
    public partial class DiceRollerTab : Page
    {
        Random random = new Random();
        (int number, int type, int modifier)? Preset1 = null;
        (int number, int type, int modifier)? Preset2 = null;
        (int number, int type, int modifier)? Preset3 = null;
        public DiceRollerTab()
        {
            InitializeComponent();
        }

        private void rollButton_Click(object sender, RoutedEventArgs e)
        {
            int[] diceRolls = new int[(int)diceNumberUpDown.Value!];
            int diceNumber = (int)diceNumberUpDown.Value;
            int modifier = (int)modifierUpDown.Value!;
            int diceType = (int)diceTypeUpDown.Value!;

            if (sender == Preset1Button && Preset1.HasValue)
            {
                diceRolls = new int[Preset1.Value.number];
                diceNumber = Preset1.Value.number;
                modifier = Preset1.Value.modifier;
                diceType = Preset1.Value.type;
            }
            if (sender == Preset2Button && Preset2.HasValue)
            {
                diceRolls = new int[Preset2.Value.number];
                diceNumber = Preset2.Value.number;
                modifier = Preset2.Value.modifier;
                diceType = Preset2.Value.type;
            }
            if (sender == Preset3Button && Preset3.HasValue)
            {
                diceRolls = new int[Preset3.Value.number];
                diceNumber = Preset3.Value.number;
                modifier = Preset3.Value.modifier;
                diceType = Preset3.Value.type;
            }



            for (int i = 0; i < diceNumber; i++)
            {
                int result = random.Next(1, diceType + 1);
                diceRolls[i] = result;
            }
            int total = diceRolls.Sum() + modifier;
            string rollResult = $"{diceNumber}d{diceType} = {string.Join(", ", diceRolls)} + {modifier} (Total: {total})";
            (App.Current as App)!.RollHistory.Push(rollResult);
            ((MainWindow)System.Windows.Application.Current.MainWindow).updateListView();
        }

        private void OverwritePresetButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == OverwritePreset1Button)
            {
                Preset1 = ((int)diceNumberUpDown.Value!, (int)diceTypeUpDown.Value!, (int)modifierUpDown.Value!);
                Preset1Button.Content = $"{Preset1.Value.number}d{Preset1.Value.type} + {Preset1.Value.modifier}";
            }
            else if (sender == OverwritePreset2Button)
            {
                Preset2 = ((int)diceNumberUpDown.Value!, (int)diceTypeUpDown.Value!, (int)modifierUpDown.Value!);
                Preset2Button.Content = $"{Preset2.Value.number}d{Preset2.Value.type} + {Preset2.Value.modifier}";
            }
            else if (sender == OverwritePreset3Button)
            {
                Preset3 = ((int)diceNumberUpDown.Value!, (int)diceTypeUpDown.Value!, (int)modifierUpDown.Value!);
                Preset3Button.Content = $"{Preset3.Value.number}d{Preset3.Value.type} + {Preset3.Value.modifier}";
            }
        }
    }
}
