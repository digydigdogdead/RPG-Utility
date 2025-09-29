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
        private Stack<string> _rollHistory = new Stack<string>();
        public Stack<string> RollHistory 
        { 
            get { return _rollHistory; }
            set 
            { 
                _rollHistory = value;
                ChangesMade();
            } 
        }
        private List<Clock> _clocks = new List<Clock>();
        public List<Clock> Clocks 
        {
            get { return _clocks; }
            set 
            { 
                _clocks = value;
                ChangesMade();
            }
        }
        private List<StatTrack> _stats = new List<StatTrack>();
        public List<StatTrack> Stats
        {
            get { return _stats; }
            set
            {
                _stats = value;
                ChangesMade();
            }
        }
        private List<Memo> _memos = new List<Memo>();
        public List<Memo> Memos
        {
            get { return _memos; }
            set
            {
                _memos = value;
                ChangesMade();
            }
        }
        private List<SessionLog> _sessionLogs = new List<SessionLog>();
        public List<SessionLog> SessionLogs 
        {
            get { return _sessionLogs; }
            set
            {
                _sessionLogs = value;
                ChangesMade();
            }
        }
        private List<Combatant> _combatants = new List<Combatant>();
        public List<Combatant> Combatants 
        {
            get { return _combatants; }
            set
            {
                _combatants = value;
                ChangesMade();
            }
        }

        public Memos? MemosPage { get; set; } = null;
        public StatTracker? StatTrackerPage { get; set; } = null;
        public SessionLogs? SessionLogsPage { get; set; } = null;
        public Clocks? ClocksPage { get; set; } = null;
        public Pages.Options? OptionsPage {get; set; } = null;
        public InitiativeTracker? InitiativeTrackerPage { get; set; } = null;
        public string? LoadedFilePath { get; set; } = null;

        public void LoadData(SaveData sd)
        {
            string potentialError = "";
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
            } catch (Exception ex)
            {
                potentialError += $" Clocks failed, {ex.Message}";
            }
            try
            {
                // Stats
                Stats.Clear();
                foreach (var stat in sd.StatsData)
                {
                    StatTrack statTrack = new StatTrack
                    {
                        Stat = stat.Name,
                        Value = stat.Value,
                        BackgroundColour = stat.BackgroundColour
                    };
                    Stats.Add(statTrack);
                }
                StatTrackerPage?.PopulateWrapPanel();
            } catch (Exception ex)
            {
                potentialError += $" Stats failed, {ex.Message}";
            }
            try
            {
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
            } catch (Exception ex)
            {
                potentialError += $" Memos failed, {ex.Message}";
            }
            try
            {
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
            } catch (Exception ex)
            {
                potentialError += $" Session Logs failed, {ex.Message}";
            }
            try
            {
                // Initiative Tracker
                Combatants.Clear();
                foreach (var combatant in sd.CombatantsData)
                {
                    Combatant newCombatant = new Combatant
                    {
                        Initiative = combatant.Initiative,
                        Hp = combatant.Hp,
                        Conditions = new(combatant.Conditions),
                        CombatantName = combatant.Name
                    };
                    Combatants.Add(newCombatant);
                }
                InitiativeTrackerPage!.CurrentTurnIndex = sd.CurrentTurnIndex;
                InitiativeTrackerPage!.UpdateTracker();
            } catch (Exception ex)
            {
                potentialError += $" Initiative failed, {ex.Message}";
            }
            try
            {
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
                if (sd.TabsData["InitiativeTracker"])
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).initiativeTrackerTab.Visibility = Visibility.Visible;
                    OptionsPage!.initiativeTrackerOption.IsChecked = true;
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).initiativeTrackerTab.Visibility = Visibility.Collapsed;
                    OptionsPage!.initiativeTrackerOption.IsChecked = false;
                }
            } catch (Exception ex)
            {
                potentialError += $" Tabs failed, {ex.Message}";
            }

            if (String.IsNullOrEmpty(potentialError))
            {
                OptionsPage!.saveStatusTextBlock.Text = "✔";
                OptionsPage!.saveStatusTextBlock.ToolTip = "Data loaded.";
                OptionsPage!.saveButton.IsEnabled = false;
            }
            else
            {
                MessageBox.Show($"Failed to load some or all data: {potentialError}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangesMade()
        {
            if (OptionsPage == null) return;
            OptionsPage.saveStatusTextBlock.Text = "~";
            OptionsPage.saveStatusTextBlock.ToolTip = "You have unsaved changes.";
            if (!String.IsNullOrEmpty(LoadedFilePath))
            {
                OptionsPage!.saveButton.IsEnabled = true;
            }
            
        }

    }

}
