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
using Microsoft.Win32;
using Newtonsoft.Json;
using RPGUtility;
using WpfApp1;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for SaveLoad.xaml
    /// </summary>
    public partial class SaveLoad : Page
    {
        public SaveLoad()
        {
            InitializeComponent();
        }

        private void saveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveData saveData = BuildSaveData();
            SaveAs(saveData);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveData saveData = BuildSaveData();
            WriteJson(saveData);
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
                    (WpfApp1.App.Current as App)!.LoadedFilePath = fileDialog.FileName;
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

            foreach (var stat in (WpfApp1.App.Current as App)!.Stats)
            {
                saveData.StatsData.Add((stat.Stat, stat.Value));
            }

            foreach (var memo in (WpfApp1.App.Current as App)!.Memos)
            {
                saveData.MemosData.Add((memo.Title, memo.MemoContent));
            }

            foreach (var log in (WpfApp1.App.Current as App)!.SessionLogs)
            {
                saveData.SessionLogsData.Add((log.SessionNumber, log.LogTitle, log.SessionDescription));
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
                (WpfApp1.App.Current as App)!.LoadedFilePath = saveFileDialog.FileName;
            }

            WriteJson(sd);
        }

        private void WriteJson(SaveData sd)
        {
            if (!string.IsNullOrEmpty((WpfApp1.App.Current as App)!.LoadedFilePath))
            {
                try
                {
                    string json = JsonConvert.SerializeObject(sd, Formatting.Indented,
                        new JsonSerializerSettings
                        {

                        });
                    System.IO.File.WriteAllText((WpfApp1.App.Current as App)!.LoadedFilePath!, json);
                    MessageBox.Show("Data saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    saveButton.IsEnabled = true;
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
    }
}
