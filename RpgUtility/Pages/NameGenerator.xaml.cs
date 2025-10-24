using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;

namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for NameGenerator.xaml
    /// </summary>
    public partial class NameGenerator : Page
    {
        List<string> maleFirstFantasyNames = new List<string>() { };
        List<string> neutralFirstFantasyNames = new List<string>() { };
        List<string> femaleFirstFantasyNames = new List<string>() { };
        List<string> fantasyEpithets = new List<string>() { };
        List<string> maleFirstModernNames = new List<string>() { };
        List<string> femaleFirstModernNames = new List<string>() { };
        List<string> neutralFirstModernNames = new List<string>() { };
        List<string> modernSurnames = new List<string>() { };
        List<string> fantasyPlaceNames = new List<string>() { };
        List<string> scifiPlaceNames = new List<string>() { };
        List<string> modernPlaceNames = new List<string>() { };
        List<string> monsterNames = new List<string>() { };

        public NameGenerator()
        {
            InitializeComponent();
            LoadNames();
        }

        private void generateNameButton_Click(object sender, RoutedEventArgs e)
        {
            if (typeComboBox.SelectedItem == fantasyPersonCbi)
            {
                Random rand = new Random();
                string firstName = "";
                string epithet = fantasyEpithets[rand.Next(fantasyEpithets.Count)];
                if (genderComboBox.SelectedItem == maleCbi)
                {
                    var joinedNames = maleFirstFantasyNames.Concat(neutralFirstFantasyNames).ToList();
                    firstName = joinedNames[rand.Next(joinedNames.Count)];
                }
                else if (genderComboBox.SelectedItem == femaleCbi)
                {
                    var joinedNames = femaleFirstFantasyNames.Concat(neutralFirstFantasyNames).ToList();
                    firstName = joinedNames[rand.Next(joinedNames.Count)];
                }
                else if (genderComboBox.SelectedItem == neutralCbi)
                {
                    firstName = neutralFirstFantasyNames[rand.Next(neutralFirstFantasyNames.Count)];
                }
                else
                {
                    var allNames = maleFirstFantasyNames.Concat(femaleFirstFantasyNames).Concat(neutralFirstFantasyNames).ToList();
                    firstName = allNames[rand.Next(allNames.Count)];
                }
                nameTextBox.Text = $"{firstName} {epithet}";
            }
            else if (typeComboBox.SelectedItem == modernPersonCbi)
            {
                Random rand = new Random();
                string firstName = "";
                string lastName = modernSurnames[rand.Next(modernSurnames.Count)];
                if (genderComboBox.SelectedItem == maleCbi)
                {
                    var joinedNames = maleFirstModernNames.Concat(neutralFirstModernNames).ToList();
                    firstName = joinedNames[rand.Next(joinedNames.Count)];
                }
                else if (genderComboBox.SelectedItem == femaleCbi)
                {
                    var joinedNames = femaleFirstModernNames.Concat(neutralFirstModernNames).ToList();
                    firstName = joinedNames[rand.Next(joinedNames.Count)];
                }
                else if (genderComboBox.SelectedItem == neutralCbi)
                {
                    firstName = neutralFirstModernNames[rand.Next(neutralFirstModernNames.Count)];
                }
                else if (genderComboBox.SelectedItem == anyCbi)
                {
                    var allNames = maleFirstModernNames.Concat(femaleFirstModernNames).Concat(neutralFirstModernNames).ToList();
                    firstName = allNames[rand.Next(allNames.Count)];
                }
                nameTextBox.Text = $"{firstName} {lastName}";
            }
            else if (typeComboBox.SelectedItem == fantasyPlaceCbi)
            {
                Random rand = new Random();
                nameTextBox.Text = fantasyPlaceNames[rand.Next(fantasyPlaceNames.Count)];
            }
            else if (typeComboBox.SelectedItem == scifiPlaceCbi)
            {
                Random rand = new Random();
                nameTextBox.Text = scifiPlaceNames[rand.Next(scifiPlaceNames.Count)];
            }
            else if (typeComboBox.SelectedItem == modernPlaceCbi)
            {
                Random rand = new Random();
                nameTextBox.Text = modernPlaceNames[rand.Next(modernPlaceNames.Count)];
            }
            else if (typeComboBox.SelectedItem == monsterCbi)
            {
                Random rand = new Random();
                nameTextBox.Text = monsterNames[rand.Next(monsterNames.Count)];
            }

        }


        private void addMemoButton_Click(object sender, RoutedEventArgs e)
        {
            NewMemoWindow newMemoWindow = new NewMemoWindow();
            if (typeComboBox.SelectedItem == fantasyPersonCbi
                || typeComboBox.SelectedItem == modernPersonCbi)
            {
                newMemoWindow.memoTitleTextBox.Text = $"Character: {nameTextBox.Text}";
            }
            else if (typeComboBox.SelectedItem == fantasyPlaceCbi
                || typeComboBox.SelectedItem == modernPlaceCbi
                || typeComboBox.SelectedItem == scifiPlaceCbi)
            {
                newMemoWindow.memoTitleTextBox.Text = $"Place: {nameTextBox.Text}";
            }
            else if (typeComboBox.SelectedItem == monsterCbi)
            {
                newMemoWindow.memoTitleTextBox.Text = $"Monster: {nameTextBox.Text}";
            }

            newMemoWindow.Show();
        }

        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (genderComboBox == null) return;
            if (typeComboBox.SelectedItem == fantasyPlaceCbi 
                || typeComboBox.SelectedItem == modernPlaceCbi 
                || typeComboBox.SelectedItem == scifiPlaceCbi
                || typeComboBox.SelectedItem == monsterCbi)
            {
                genderComboBox.SelectedItem = neutralCbi;
                genderComboBox.IsEnabled = false;
            }
            else genderComboBox.IsEnabled = true;
        }

        public void LoadNames()
        {
            // make paths robust at runtime (use AppContext.BaseDirectory)
            string dataDir = Path.Combine(AppContext.BaseDirectory, "Random Names");

            var missing = new List<string>();

            maleFirstFantasyNames = ReadLinesSafe(Path.Combine(dataDir, "male_fantasy_first_names.txt"), missing);
            femaleFirstFantasyNames = ReadLinesSafe(Path.Combine(dataDir, "female_fantasy_first_names.txt"), missing);
            neutralFirstFantasyNames = ReadLinesSafe(Path.Combine(dataDir, "neutral_fantasy_first_names.txt"), missing);
            fantasyEpithets = ReadLinesSafe(Path.Combine(dataDir, "fantasy_epithets.txt"), missing);

            maleFirstModernNames = ReadLinesSafe(Path.Combine(dataDir, "male_modern_first_names.txt"), missing);
            femaleFirstModernNames = ReadLinesSafe(Path.Combine(dataDir, "female_modern_first_names.txt"), missing);
            neutralFirstModernNames = ReadLinesSafe(Path.Combine(dataDir, "neutral_modern_first_names.txt"), missing);
            modernSurnames = ReadLinesSafe(Path.Combine(dataDir, "modern_surnames.txt"), missing);

            fantasyPlaceNames = ReadLinesSafe(Path.Combine(dataDir, "fantasy_place_names.txt"), missing);
            scifiPlaceNames = ReadLinesSafe(Path.Combine(dataDir, "scifi_place_names.txt"), missing);
            modernPlaceNames = ReadLinesSafe(Path.Combine(dataDir, "modern_place_names.txt"), missing);
            monsterNames = ReadLinesSafe(Path.Combine(dataDir, "monster_names.txt"), missing);

            if (missing.Any())
            {
                MessageBox.Show(
                    $"Could not find {missing.Count} data file(s).\n\nCurrentDir: {Directory.GetCurrentDirectory()}\nBaseDir: {AppContext.BaseDirectory}\n\nMissing:\n{string.Join("\n", missing)}",
                    "Data files not found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private List<string> ReadLinesSafe(string relativePath, List<string> missing)
        {
            try
            {
                var full = ResolveDataPath(relativePath);
                return File.ReadAllLines(full).ToList();
            }
            catch (FileNotFoundException)
            {
                missing?.Add(relativePath);
                return new List<string>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading '{relativePath}': {ex.Message}", "Read error", MessageBoxButton.OK, MessageBoxImage.Error);
                missing?.Add(relativePath);
                return new List<string>();
            }
        }

        private string ResolveDataPath(string relativePath)
        {
            // Try a set of sensible locations (exe base, working dir, assembly location, a couple up-level guesses)
            var baseDir = AppContext.BaseDirectory;
            var asmDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? baseDir;
            var candidates = new[]
            {
                Path.Combine(baseDir, relativePath),
                Path.Combine(Directory.GetCurrentDirectory(), relativePath),
                Path.Combine(asmDir, relativePath),
                Path.GetFullPath(Path.Combine(baseDir, "..", relativePath)),
                Path.GetFullPath(Path.Combine(baseDir, "..", "..", relativePath))
            };

            foreach (var c in candidates)
            {
                try
                {
                    if (File.Exists(c)) return c;
                }
                catch { /* ignore malformed paths */ }
            }

            throw new FileNotFoundException($"Data file not found: '{relativePath}'. Searched {candidates.Length} locations.");
        }
    }
}
