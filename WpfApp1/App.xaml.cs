using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp1.Controls;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Stack<string> RollHistory = new Stack<string>();
        public List<Clock> Clocks = new List<Clock>();
        public List<StatTrack> Stats = new List<StatTrack>();
        public List<Memo> Memos = new List<Memo>();
        public List<SessionLog> SessionLogs = new List<SessionLog>();

        public Memos? MemosPage { get; set; } = null;
        public StatTracker? StatTrackerPage { get; set; } = null;
        public SessionLogs? SessionLogsPage { get; set; } = null;







    }

}
