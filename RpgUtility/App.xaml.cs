using RPGUtility;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using RPGUtility.Controls;
using RPGUtility.Pages;

namespace RPGUtility
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
        public Pages.Options? OptionsPage {get; set; } = null;
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

                // Tabs
                if (sd.TabsData["DiceRoller"])
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).diceRollerTab.Visibility = Visibility.Visible;
                    OptionsPage!.diceRollerOption.IsChecked = true;
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).diceRollerTab.Visibility = Visibility.Collapsed;
                    OptionsPage!.diceRollerOption.IsChecked = false;
                }
                if (sd.TabsData["Clocks"])
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).clocksTab.Visibility = Visibility.Visible;
                    OptionsPage!.clocksOption.IsChecked = true;
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).clocksTab.Visibility = Visibility.Collapsed;
                    OptionsPage!.clocksOption.IsChecked = false;
                }
                if (sd.TabsData["StatTracker"])
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).statTrackerTab.Visibility = Visibility.Visible;
                    OptionsPage!.statTrackerOption.IsChecked = true;
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).statTrackerTab.Visibility = Visibility.Collapsed;
                    OptionsPage!.statTrackerOption.IsChecked = false;
                }
                if (sd.TabsData["Memos"])
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).memosTab.Visibility = Visibility.Visible;
                    OptionsPage!.memosOption.IsChecked = true;
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).memosTab.Visibility = Visibility.Collapsed;
                    OptionsPage!.memosOption.IsChecked = false;
                }
                if (sd.TabsData["SessionLogs"])
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).sessionLogsTab.Visibility = Visibility.Visible;
                    OptionsPage!.sessionLogsOption.IsChecked = true;
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).sessionLogsTab.Visibility = Visibility.Collapsed;
                    OptionsPage!.sessionLogsOption.IsChecked = false;
                }
                if (sd.TabsData["NameGenerator"])
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).nameGeneratorTab.Visibility = Visibility.Visible;
                    OptionsPage!.nameGeneratorOption.IsChecked = true;
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).nameGeneratorTab.Visibility = Visibility.Collapsed;
                    OptionsPage!.nameGeneratorOption.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }

}
