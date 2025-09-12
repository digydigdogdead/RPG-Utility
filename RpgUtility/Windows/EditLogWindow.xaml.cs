using System.Windows;
using System.Windows.Input;

namespace RPGUtility.Windows
{
    /// <summary>
    /// Interaction logic for EditLogWindow.xaml
    /// </summary>
    public partial class EditLogWindow : Window
    {
        public int LogIndex { get; set; }
        public EditLogWindow()
        {
            InitializeComponent();
        }

        private void overwriteLogButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.SessionLogs[LogIndex].SessionDescription = sessionDescriptionTextBox.Text;
            (App.Current as App)!.SessionLogs[LogIndex].SessionNumber = (int)sessionNumberUpDown.Value!;
            (App.Current as App)!.SessionLogs[LogIndex].LogTitle = sessionTitleTextBox.Text;
            (App.Current as App)!.SessionLogsPage!.RefreshLogs();
            this.Close();
        }

        private void deleteLogButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App)!.SessionLogs.RemoveAt(LogIndex);
            (App.Current as App)!.SessionLogsPage!.RefreshLogs();
            this.Close();
        }

        private void sessionDescriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift)) sessionDescriptionTextBox.AcceptsReturn = true;

            if (e.Key == Key.Enter) overwriteLogButton_Click(sender, e);
        }

        private void sessionDescriptionTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift) sessionDescriptionTextBox.AcceptsReturn = false;
        }
    }
}
