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

namespace WpfApp1.Pages
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
            Windows.NewLogWindow newLogWindow = new Windows.NewLogWindow();
            newLogWindow.ShowDialog();
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
