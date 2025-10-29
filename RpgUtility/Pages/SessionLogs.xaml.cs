using RPGUtility.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

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

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchQuery = from log in (Application.Current as App)!.SessionLogs
                              where log.LogTitle.ToLower().Contains(searchTextBox.Text.ToLower()) || log.SessionDescription.ToLower().Contains(searchTextBox.Text.ToLower())
                              select log;
            sessionLogsWrapPanel.Children.Clear();
            foreach (var log in searchQuery)
            {
                sessionLogsWrapPanel.Children.Add(log);
            }
        }

        private void clearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = string.Empty;
            RefreshLogs();
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("""
                
                This page allows you to create and manage session logs for your RPG campaigns.
                
                Click the "+" button to create a new log entry. You can use session logs to document important events, character actions, and plot developments that occur during your game sessions.
                
                You can edit or delete existing session logs by right-clicking or double-clicking on them.
                
                Use the search box to quickly find specific logs by title or description.

                If you have initialised a calendar, you can add your session logs to the calendar at the same time as making them.
                
                """, "Session Logs Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
