using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections;
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

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for SaveLoad.xaml
    /// </summary>
    public partial class Options : Page
    {
        public Options()
        {
            InitializeComponent();
            (App.Current as App)!.OptionsPage = this;
        }

        private void saveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveAs(BuildSaveData());
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            WriteJson(BuildSaveData());
        }

        private async void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = ".json",
                Multiselect = false
            };

            Nullable<bool> result = fileDialog.ShowDialog();

            if (result != null && result.Value)
            {
                try
                {
                    SaveData loadedData = new SaveData();
                    await Task.Run(() =>
                        { 
                            string json = System.IO.File.ReadAllText(fileDialog.FileName);
                            loadedData = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveData>(json)!; 
                        });
                    (App.Current as App)!.LoadedFilePath = fileDialog.FileName;
                    (App.Current as App)!.LoadData(loadedData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        private SaveData BuildSaveData()
        {
            SaveData saveData = new SaveData();

            foreach (var clock in (App.Current as App)!.Clocks)
            {
                saveData.ClocksData.Add((clock.Segments, clock.ClockName, clock.FilledSegments));
            }

            foreach (var stat in (App.Current as App)!.Stats)
            {
                saveData.StatsData.Add((stat.Stat, stat.Value, stat.BackgroundColour));
            }

            foreach (var memo in (App.Current as App)!.Memos)
            {
                saveData.MemosData.Add((memo.Title, memo.MemoContent));
            }

            foreach (var log in (App.Current as App)!.SessionLogs)
            {
                saveData.SessionLogsData.Add((log.SessionNumber, log.LogTitle, log.SessionDescription));
            }

            foreach (var combatant in (App.Current as App)!.Combatants)
            {
                saveData.CombatantsData.Add((combatant.CombatantName, combatant.Initiative, combatant.Hp, new List<string>(combatant.Conditions)));
            }
            saveData.CurrentTurnIndex = (int)(App.Current as App)!.InitiativeTrackerPage?.CurrentTurnIndex!;

            // Tabs
            if (((MainWindow)System.Windows.Application.Current.MainWindow).diceRollerTab.Visibility == Visibility.Visible)
            {
                saveData.TabsData["DiceRoller"] = true;
            }
            else
            {
                saveData.TabsData["DiceRoller"] = false;
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).clocksTab.Visibility == Visibility.Visible)
            {
                saveData.TabsData["Clocks"] = true;
            }
            else
            {
                saveData.TabsData["Clocks"] = false;
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).statTrackerTab.Visibility == Visibility.Visible)
            {
                saveData.TabsData["StatTracker"] = true;
            }
            else
            {
                saveData.TabsData["StatTracker"] = false;
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).memosTab.Visibility == Visibility.Visible)
            {
                saveData.TabsData["Memos"] = true;
            }
            else
            {
                saveData.TabsData["Memos"] = false;
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).sessionLogsTab.Visibility == Visibility.Visible)
            {
                saveData.TabsData["SessionLogs"] = true;
            }
            else
            {
                saveData.TabsData["SessionLogs"] = false;
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).nameGeneratorTab.Visibility == Visibility.Visible)
            {
                saveData.TabsData["NameGenerator"] = true;
            }
            else
            {
                saveData.TabsData["NameGenerator"] = false;
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).initiativeTrackerTab.Visibility == Visibility.Visible)
            {
                saveData.TabsData["InitiativeTracker"] = true;
            }
            else
            {
                saveData.TabsData["InitiativeTracker"] = false;
            }
            if (((MainWindow)System.Windows.Application.Current.MainWindow).calendarTab.Visibility == Visibility.Visible)
            {
                saveData.TabsData["Calendar"] = true;
            }
            else
            {
                saveData.TabsData["Calendar"] = false;
            }

            return saveData;
        }

        private void SaveAs(SaveData sd)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                DefaultExt = ".json",
                AddExtension = true,
                FileName = "RPGUtility_SaveData.json"
            };

            Nullable<bool> result = saveFileDialog.ShowDialog();

            if (result != null && result.Value)
            {
                (App.Current as App)!.LoadedFilePath = saveFileDialog.FileName;
            }

            WriteJson(sd);
        }

        private void WriteJson(SaveData sd)
        {
            if (!string.IsNullOrEmpty((App.Current as App)!.LoadedFilePath))
            {
                try
                {
                    string json = JsonConvert.SerializeObject(sd, Formatting.Indented);
                    System.IO.File.WriteAllText((App.Current as App)!.LoadedFilePath!, json);
                    saveStatusTextBlock.Text = "✔️";
                    saveButton.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Save operation was cancelled or no file path specified.", "Cancelled", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OptionChecked(object sender, RoutedEventArgs e)
        {
            if (sender == diceRollerOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).diceRollerTab.Visibility = Visibility.Visible;
            }
            else if (sender == clocksOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).clocksTab.Visibility = Visibility.Visible;
            }
            else if (sender == statTrackerOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).statTrackerTab.Visibility = Visibility.Visible;
            }
            else if (sender == memosOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).memosTab.Visibility = Visibility.Visible;
            }
            else if (sender == sessionLogsOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).sessionLogsTab.Visibility = Visibility.Visible;
            }
            else if (sender == nameGeneratorOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).nameGeneratorTab.Visibility = Visibility.Visible;
            }
            else if (sender == initiativeTrackerOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).initiativeTrackerTab.Visibility = Visibility.Visible;
            }
            else if (sender == calendarOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).calendarTab.Visibility = Visibility.Visible;
            }
        }

        private void OptionUnchecked(object sender, RoutedEventArgs e)
        {
            if (sender == diceRollerOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).diceRollerTab.Visibility = Visibility.Collapsed;
            }
            else if (sender == clocksOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).clocksTab.Visibility = Visibility.Collapsed;
            }
            else if (sender == statTrackerOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).statTrackerTab.Visibility = Visibility.Collapsed;
            }
            else if (sender == memosOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).memosTab.Visibility = Visibility.Collapsed;
            }
            else if (sender == sessionLogsOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).sessionLogsTab.Visibility = Visibility.Collapsed;
            }
            else if (sender == nameGeneratorOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).nameGeneratorTab.Visibility = Visibility.Collapsed;
            }
            else if (sender == initiativeTrackerOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).initiativeTrackerTab.Visibility = Visibility.Collapsed;
            }
            else if (sender == calendarOption)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).calendarTab.Visibility = Visibility.Collapsed;
            }
        }
    }
}
