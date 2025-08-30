using RPGUtility;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
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
        public Clocks? ClocksPage { get; set; } = null;
        public string? LoadedFilePath { get; set; } = null;

        public void LoadData(SaveData sd)
        {
            try
            {
                // Clocks
                Clocks.Clear();
                foreach (var clockDatum in sd.ClocksData)
                {
                    Clock clock = new Clock
                    {
                        Segments = clockDatum.Segments,
                        ClockName = clockDatum.Name,
                        FilledSegments = clockDatum.Filled
                    };
                    Clocks.Add(clock);
                }
                ClocksPage?.UpdateClockStack();
                // Stats
                Stats.Clear();
                foreach (var stat in sd.StatsData)
                {
                    StatTrack statTrack = new StatTrack
                    {
                        Stat = stat.Name,
                        Value = stat.Value
                    };
                    Stats.Add(statTrack);
                }
                StatTrackerPage?.PopulateWrapPanel();
                // Memos
                Memos.Clear();
                foreach (var memoDatum in sd.MemosData)
                {
                    Memo memo = new Memo
                    {
                        Title = memoDatum.Title,
                        MemoContent = memoDatum.Content
                    };
                    Memos.Add(memo);
                }
                MemosPage?.RefreshMemos();
                // Session Logs
                SessionLogs.Clear();
                foreach (var logDatum in sd.SessionLogsData)
                {
                    SessionLog sessionLog = new SessionLog
                    {
                        SessionNumber = logDatum.SessionNumber,
                        LogTitle = logDatum.LogTitle,
                        SessionDescription = logDatum.SessionDescription
                    };
                    SessionLogs.Add(sessionLog);
                }
                SessionLogsPage?.RefreshLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }

}
