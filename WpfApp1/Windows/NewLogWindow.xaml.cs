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
using WpfApp1.Controls;

namespace WpfApp1.Windows
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
            if (e.Key == Key.Enter)
            {
                saveLogButton_Click(sender, e);
            }
        }
    }
}
