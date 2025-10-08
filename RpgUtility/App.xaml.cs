using System.Collections.ObjectModel;
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
        public ObservableCollection<Clock> Clocks { get; set; } = new ObservableCollection<Clock>();
        public ObservableCollection<StatTrack> Stats { get; set; } = new();
        public ObservableCollection<Memo> Memos { get; set; } = new();
        public ObservableCollection<SessionLog> SessionLogs { get; set; } = new();
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

        public ObservableCollection<Day> DaysInCalendar { get; set; } = new ObservableCollection<Day>();
        public Dictionary<string, int> MonthsToDays { get; set; } = new Dictionary<string, int>();
        private int _currentMonthIndex = 0;
        public int CurrentMonthIndex 
        {
            get { return _currentMonthIndex; }
            set 
            {
                _currentMonthIndex = value;
                CalendarPage!.currentCalendar!.CurrentMonthIndex = value;
                if (!isLoading)
                {
                    CalendarPage?.currentCalendar?.PopulateCalendar();
                    ChangesMade();
                }
            }
        }
        private int _currentYear = 1000;
        public int CurrentYear 
        {
            get { return _currentYear; }
            set 
            {
                _currentYear = value;
                CalendarPage!.currentCalendar!.CurrentYear = value;
                if (!isLoading)
                {
                    CalendarPage?.currentCalendar?.PopulateCalendar();
                    ChangesMade();
                }
            } 
        }

        public bool isLoading { get; set; } = false;

        public App()
        {
            DaysInCalendar.CollectionChanged += (s, e) =>
            {
                if (isLoading) return;
                if (DaysInCalendar.Count > 0)
                {
                    CalendarPage!.currentCalendar!.PrevMonthButton.IsEnabled = true;
                    CalendarPage!.currentCalendar!.NextMonthButton.IsEnabled = true;
                }
                CalendarPage?.currentCalendar?.PopulateCalendar();
                ChangesMade();
            };
            Clocks.CollectionChanged += (s, e) =>
            {
                if (isLoading) return;
                ClocksPage?.UpdateClockStack();
                ChangesMade();
            };
            Stats.CollectionChanged += (s, e) =>
            {
                if (isLoading) return;
                StatTrackerPage?.PopulateWrapPanel();
                ChangesMade();
            };
            Memos.CollectionChanged += (s, e) =>
            {
                if (isLoading) return;
                MemosPage?.RefreshMemos();
                ChangesMade();
            };
            SessionLogs.CollectionChanged += (s, e) =>
            {
                if (isLoading) return;
                SessionLogsPage?.RefreshLogs();
                ChangesMade();
            };
        }

        public Memos? MemosPage { get; set; } = null;
        public StatTracker? StatTrackerPage { get; set; } = null;
        public SessionLogs? SessionLogsPage { get; set; } = null;
        public Clocks? ClocksPage { get; set; } = null;
        public Pages.Options? OptionsPage {get; set; } = null;
        public InitiativeTracker? InitiativeTrackerPage { get; set; } = null;
        public CalendarPage? CalendarPage { get; set; } = null;
        public string? LoadedFilePath { get; set; } = null;

        public void LoadData(SaveData sd)
        {
            isLoading = true;
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
                // Calendar
                if (sd.DaysData.Count > 0)
                {
                    DaysInCalendar.Clear();
                    MonthsToDays = new(sd.MonthsToDays);
                    CurrentMonthIndex = sd.CurrentMonthIndex;
                    CurrentYear = sd.CurrentYear;
                
                    foreach (var dayDatum in sd.DaysData)
                    {
                        Day day = new Day
                        {
                            DayNumber = dayDatum.DayNumber,
                            Month = dayDatum.MonthName,
                            Year = dayDatum.Year,
                            Events = new(dayDatum.Events)
                        };
                        DaysInCalendar.Add(day);
                    }
                    CalendarPage?.currentCalendar?.PopulateCalendar();
                    CalendarPage!.currentCalendar!.PrevMonthButton.IsEnabled = true;
                    CalendarPage!.currentCalendar!.NextMonthButton.IsEnabled = true;
                }
            } catch (Exception ex)
            {
                potentialError += $" Calendar failed, {ex.Message}";
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
                if (sd.TabsData["Calendar"])
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).calendarTab.Visibility = Visibility.Visible;
                    OptionsPage!.calendarOption.IsChecked = true;
                }
                else
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).calendarTab.Visibility = Visibility.Collapsed;
                    OptionsPage!.calendarOption.IsChecked = false;
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

            isLoading = false;
        }

        public void ChangesMade()
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
