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
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : UserControl
    {
        public static readonly DependencyProperty SegmentsProperty = DependencyProperty.Register(
            nameof(Segments), typeof(int), typeof(Clock), new PropertyMetadata(4, OnSegmentsChanged()));
        public int Segments
        {
            get { return (int)GetValue(SegmentsProperty); }
            set { SetValue(SegmentsProperty, value); }
        }
        public static readonly DependencyProperty DefaultColorProperty = DependencyProperty.Register(
            nameof(DefaultColor), typeof(Color), typeof(Clock), new PropertyMetadata(Colors.LightGray));
        public Color DefaultColor
        {
            get { return (Color)GetValue(DefaultColorProperty); }
            set { SetValue(DefaultColorProperty, value); }
        }
        public static readonly DependencyProperty FilledColorProperty = DependencyProperty.Register(
            nameof(FilledColor), typeof(Color), typeof(Clock), new PropertyMetadata(Colors.ForestGreen));
        public Color FilledColor
        {
            get { return (Color)GetValue(FilledColorProperty); }
            set { SetValue(FilledColorProperty, value); }
        }
        public static readonly DependencyProperty SquareSizeProperty = DependencyProperty.Register(
            nameof(SquareSize), typeof(int), typeof(Clock), new PropertyMetadata(45));
        public int SquareSize
        {
            get { return (int)GetValue(SquareSizeProperty); }
            set { SetValue(SquareSizeProperty, value); }
        }

        public Clock()
        {
            InitializeComponent();
            BuildClock();

        }
        public void BuildClock()
        {
            // Clear existing segments
            clockStack.Children.Clear();
            // Create new segments based on the Segments property
            for (int i = 0; i < Segments; i++)
            {
                Rectangle segment = new Rectangle
                {
                    Width = SquareSize,
                    Height = SquareSize,
                    Fill = new SolidColorBrush(DefaultColor),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                clockStack.Children.Add(segment);

                if (i != Segments - 1)
                {
                    // Add a separator between segments
                    Line separator = new Line
                    {
                        Stroke = new SolidColorBrush(Colors.Black),
                        StrokeThickness = 2,
                        X1 = 0,
                        Y1 = 22,
                        X2 = 40,
                        Y2 = 22,
                        Margin = new Thickness(0, 5, 0, 0)
                    };
                    clockStack.Children.Add(separator);
                }
            }
        }
        private static PropertyChangedCallback OnSegmentsChanged()
        {
            return (d, e) =>
            {
                Clock clock = (Clock)d;
                clock.BuildClock();
            };
        }

        private void clockStack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < clockStack.Children.Count; i += 2)
            {
                if (clockStack.Children[i] is Rectangle rect)
                {
                    if (rect.Fill is SolidColorBrush brush && brush.Color == DefaultColor)
                    {
                        rect.Fill = new SolidColorBrush(FilledColor);
                        break;
                    }
                }
            }
           
        }
    }
}
