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

namespace WpfApp1.Windows
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
            if (e.Key == Key.Enter)
            {
                overwriteLogButton_Click(sender, e);
            }
        }
    }
}
