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

namespace WpfApp1.Controls
{
    /// <summary>
    /// Interaction logic for StatTrack.xaml
    /// </summary>
    public partial class StatTrack : UserControl
    {
        public StatTrack()
        {
            InitializeComponent();
            BuildStatTrack();
        }
        public static readonly DependencyProperty StatProperty = DependencyProperty.Register(
            nameof(Stat), typeof(string), typeof(StatTrack), new PropertyMetadata("Stat", OnStatChanged()));
        public string Stat
        {
            get { return (string)GetValue(StatProperty); }
            set { SetValue(StatProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value), typeof(int), typeof(StatTrack), new PropertyMetadata(1, OnValueChanged()));
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static PropertyChangedCallback OnStatChanged()
        {
            return (d, e) =>
            {
                StatTrack statTrack = (StatTrack)d;
                if (statTrack.statNameTextBlock != null)
                {
                    statTrack.statNameTextBlock.Text = statTrack.Stat;
                }
            };
        }
        private static PropertyChangedCallback OnValueChanged()
        {
            return (d, e) =>
            {
                StatTrack statTrack = (StatTrack)d;
                if (statTrack.statValueIntegerUpDown != null)
                {
                    statTrack.statValueIntegerUpDown.Value = statTrack.Value;
                }
            };
        }
        public void BuildStatTrack()
        {
            // Set the initial values for the text block and integer up-down control
            if (statNameTextBlock != null)
            {
                statNameTextBlock.Text = Stat;
            }
            if (statValueIntegerUpDown != null)
            {
                statValueIntegerUpDown.Value = Value;
            }
        }
    }
}
