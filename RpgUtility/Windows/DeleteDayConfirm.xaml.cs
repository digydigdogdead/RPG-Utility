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
using RPGUtility.Controls;

namespace RPGUtility.Windows
{
    /// <summary>
    /// Interaction logic for DeleteDayConfirm.xaml
    /// </summary>
    public partial class DeleteDayConfirm : Window
    {
        private Day? _dayToDelete = null;
        public Day? DayToDelete 
        { 
            get { return _dayToDelete; }
            set 
            { 
                _dayToDelete = value;  
                MessageText.Text = $"Are you sure you want to delete {DayToDelete?.DayNumber} {DayToDelete?.Month}, {DayToDelete?.Year}?";
            }
        }
        public DeleteDayConfirm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender != ConfirmButton || DayToDelete == null) 
            { 
                Close(); 
                return;
            }

            (App.Current as App)!.DaysInCalendar.Remove(DayToDelete);
            (App.Current as App)!.CalendarPage!.currentCalendar!.PopulateCalendar();
            Close();
        }
    }
}
