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
            ((App)Application.Current).SessionLogsPage?.RefreshLogs();
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
    }
}
