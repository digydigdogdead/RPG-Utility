using System.Windows;
using System.Windows.Input;
using RPGUtility.Controls;

namespace RPGUtility.Windows
{
    /// <summary>
    /// Interaction logic for NewLogWindow.xaml
    /// </summary>
    public partial class NewLogWindow : Window
    {
        public NewLogWindow()
        {
            InitializeComponent();
            if ((App.Current as App)!.MonthsToDays.Count == 0)
            {
                calendarButton.IsEnabled = false;
            }
        }

        private void saveLogButton_Click(object sender, RoutedEventArgs e)
        {
            SessionLog newLog = new SessionLog()
            {
                LogTitle = sessionTitleTextBox.Text,
                SessionDescription = sessionDescriptionTextBox.Text,
                SessionNumber = (int)sessionNumberUpDown.Value!
            };
            ((App)Application.Current).SessionLogs.Add(newLog);
            this.Close();
        }

        private void sessionDescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift)) sessionDescriptionTextBox.AcceptsReturn = true;

            if (e.Key == Key.Enter) saveLogButton_Click(sender, e);
        }

        private void sessionDescriptionTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift) sessionDescriptionTextBox.AcceptsReturn = false;
        }

        private void calendarButton_Click(object sender, RoutedEventArgs e)
        {
            SessionLog newLog = new SessionLog()
            {
                LogTitle = sessionTitleTextBox.Text,
                SessionDescription = sessionDescriptionTextBox.Text,
                SessionNumber = (int)sessionNumberUpDown.Value!
            };
            ((App)Application.Current).SessionLogs.Add(newLog);

            AddToCalendarWindow addToCalendarWindow = new AddToCalendarWindow();
            addToCalendarWindow.eventTitleTextBox.Text = sessionTitleTextBox.Text;
            addToCalendarWindow.yearUpDown.Value = ((App)Application.Current).CurrentYear;
            addToCalendarWindow.ShowDialog();
            this.Close();
        }
    }
}
