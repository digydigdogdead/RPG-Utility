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
    /// Interaction logic for SessionLog.xaml
    /// </summary>
    public partial class SessionLog : UserControl
    {
        public static DependencyProperty SessionNumberPropery = DependencyProperty.Register("SessionNumber", typeof(int), typeof(SessionLog), new PropertyMetadata(0, OnLogNumberChanged()));
        public int SessionNumber
        {
            get { return (int)GetValue(SessionNumberPropery); }
            set { SetValue(SessionNumberPropery, value); }
        }
        public static DependencyProperty LogTitleProperty = DependencyProperty.Register("LogTitle", typeof(string), typeof(SessionLog), new PropertyMetadata(string.Empty, OnLogTitleChanged()));
        public string LogTitle
        {
            get { return (string)GetValue(LogTitleProperty); }
            set { SetValue(LogTitleProperty, value); }
        }
        public static DependencyProperty SessionDescriptionProperty = DependencyProperty.Register("SessionDescription", typeof(string), typeof(SessionLog), new PropertyMetadata(string.Empty, OnSessionDescriptionChanged()));
        public string SessionDescription
        {
            get { return (string)GetValue(SessionDescriptionProperty); }
            set { SetValue(SessionDescriptionProperty, value); }
        }
        public SessionLog()
        {
            InitializeComponent();
            numTextBlock.Text = SessionNumber.ToString();
            titleTextBlock.Text = LogTitle;
        }

        private void SessionLog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private static PropertyChangedCallback OnLogNumberChanged()
        {
            return (d, e) =>
            {
                if (d is SessionLog log && e.NewValue is int newNumber)
                {
                    log.numTextBlock.Text = newNumber.ToString();
                }
            };
        }

        private static PropertyChangedCallback OnLogTitleChanged()
        {
            return (d, e) =>
            {
                if (d is SessionLog log && e.NewValue is string newTitle)
                {
                    if (newTitle.Length < 35)
                    {
                        log.titleTextBlock.Text = newTitle;
                    }
                    else
                    {
                        log.titleTextBlock.Text = newTitle.Substring(0, 35) + "...";
                    }
                    
                }
            };
        }

        private static PropertyChangedCallback OnSessionDescriptionChanged()
        {
            return (d, e) =>
            {
                if (d is SessionLog log && e.NewValue is string newDesc)
                {
                    log.ToolTip = newDesc;
                }
            };
        }
    }
}
