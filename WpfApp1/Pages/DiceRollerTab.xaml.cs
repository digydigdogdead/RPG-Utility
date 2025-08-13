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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for DiceRollerTab.xaml
    /// </summary>
    public partial class DiceRollerTab : Page
    {
        Random random = new Random();
        public DiceRollerTab()
        {
            InitializeComponent();
        }

        private void rollButton_Click(object sender, RoutedEventArgs e)
        {
            int[] diceRolls = new int[(int)diceNumberUpDown.Value!];
            for (int i = 0; i < diceNumberUpDown.Value; i++)
            {
                int result = random.Next(1, (int)diceTypeUpDown.Value! + 1);
                diceRolls[i] = result;
            }
            int total = diceRolls.Sum() + (int)modifierUpDown.Value!;
            string rollResult = $"{diceNumberUpDown.Value}d{diceTypeUpDown.Value} = {string.Join(", ", diceRolls)} + {modifierUpDown.Value} (Total: {total})";
            (App.Current as App)!.rollHistory.Push(rollResult);
            ((MainWindow)System.Windows.Application.Current.MainWindow).updateListView();
        }
    }
}
