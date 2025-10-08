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

namespace RPGUtility.Controls
{
    /// <summary>
    /// Interaction logic for StatTrack.xaml
    /// </summary>
    public partial class StatTrack : UserControl
    {
        public StatTrack()
        {
            InitializeComponent();
            if (statNameTextBlock != null)
            {
                statNameTextBlock.Text = Stat;
            }
            if (statValueIntegerUpDown != null)
            {
                statValueIntegerUpDown.Value = Value;
            }
            Background = new SolidColorBrush(BackgroundColour);
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
        public static readonly DependencyProperty BackgroundColourProperty = DependencyProperty.Register(
            nameof(BackgroundColour), typeof(Color), typeof(StatTrack), new PropertyMetadata(Colors.Transparent, OnBackgroundColourChanged()));

        public Color BackgroundColour
        {
            get { return (Color)GetValue(BackgroundColourProperty); }
            set { SetValue(BackgroundColourProperty, value); }
        }

        private static PropertyChangedCallback OnBackgroundColourChanged()
        {
            return (d, e) =>
            {
                StatTrack statTrack = (StatTrack)d;
                if (statTrack != null)
                {
                    statTrack.Background = new SolidColorBrush(statTrack.BackgroundColour);
                }
                (App.Current as App)!.ChangesMade();
            };
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
                (App.Current as App)!.ChangesMade();
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
                (App.Current as App)!.ChangesMade();
            };
        }

        private void ChangeColour_Click(object sender, RoutedEventArgs e)
        {
            int index = ((App)Application.Current).Stats.IndexOf(this);

            if (sender == redOption)
            {
                ((App)Application.Current).Stats[index].BackgroundColour = Colors.PaleVioletRed;
            }
            else if (sender == blueOption)
            {
                ((App)Application.Current).Stats[index].BackgroundColour = Colors.LightBlue;
            }
            else if (sender == greenOption)
            {
                ((App)Application.Current).Stats[index].BackgroundColour = Colors.ForestGreen;
            }
            else if (sender == yellowOption)
            {
                ((App)Application.Current).Stats[index].BackgroundColour = Colors.LightYellow;
            }
            else if (sender == orangeOption)
            {
                ((App)Application.Current).Stats[index].BackgroundColour = Colors.Orange;
            }
            else if (sender == pinkOption)
            {
                ((App)Application.Current).Stats[index].BackgroundColour = Colors.LightPink;
            }

            (App.Current as App)!.ChangesMade();

        }
        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.Stats.Remove(this);
        }

        private void statValueIntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Value = (int)(statValueIntegerUpDown.Value ?? 1);
            (App.Current as App)!.ChangesMade();
        }
    }
}
