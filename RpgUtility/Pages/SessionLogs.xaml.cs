using RPGUtility.Windows;
using System.Windows;
using System.Windows.Controls;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for SessionLogs.xaml
    /// </summary>
    public partial class SessionLogs : Page
    {
        public SessionLogs()
        {
            InitializeComponent();
            ((Application.Current as App)!.SessionLogsPage) = this;
            RefreshLogs();
        }

        private void addSessionLogButton_Click(object sender, RoutedEventArgs e)
        {
            new NewLogWindow().Show();
        }

        public void RefreshLogs()
        {
            sessionLogsWrapPanel.Children.Clear();
            foreach (var log in ((App)Application.Current).SessionLogs)
            {
                sessionLogsWrapPanel.Children.Add(log);
            }
        }
    }
}
