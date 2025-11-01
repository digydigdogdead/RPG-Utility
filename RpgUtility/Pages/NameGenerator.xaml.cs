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
        List<string>? maleFirstFantasyNames = new List<string>() { };
        List<string>? neutralFirstFantasyNames = new List<string>() { };
        List<string>? femaleFirstFantasyNames = new List<string>() { };
        List<string>? fantasyEpithets = new List<string>() { };
        List<string>? maleFirstModernNames = new List<string>() { };
        List<string>? femaleFirstModernNames = new List<string>() { };
        List<string>? neutralFirstModernNames = new List<string>() { };
        List<string>? modernSurnames = new List<string>() { };
        List<string>? fantasyPlaceNames = new List<string>() { };
        List<string>? scifiPlaceNames = new List<string>() { };
        List<string>? modernPlaceNames = new List<string>() { };
        List<string>? monsterNames = new List<string>() { };      

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
                    string epithet = fantasyEpithets![rand.Next(fantasyEpithets.Count)];
                if (genderComboBox.SelectedItem == maleCbi)
                {
                    var joinedNames = maleFirstFantasyNames!.Concat(neutralFirstFantasyNames!).ToList();
                    firstName = joinedNames[rand.Next(joinedNames.Count)];
                }
                else if (genderComboBox.SelectedItem == femaleCbi)
                {
                    var joinedNames = femaleFirstFantasyNames!.Concat(neutralFirstFantasyNames!).ToList();
                    firstName = joinedNames[rand.Next(joinedNames.Count)];
                }
                else if (genderComboBox.SelectedItem == neutralCbi)
                {
                    firstName = neutralFirstFantasyNames![rand.Next(neutralFirstFantasyNames.Count)];
                }
                else
                {
                    var allNames = maleFirstFantasyNames!.Concat(femaleFirstFantasyNames!).Concat(neutralFirstFantasyNames!).ToList();
                    firstName = allNames[rand.Next(allNames.Count)];
                }
                nameTextBox.Text = $"{firstName} the {epithet}";
            }
            else if (typeComboBox.SelectedItem == modernPersonCbi)
            {
                Random rand = new Random();
                string firstName = "";
                string lastName = modernSurnames![rand.Next(modernSurnames.Count)];
                if (genderComboBox.SelectedItem == maleCbi)
                {
                    var joinedNames = maleFirstModernNames!.Concat(neutralFirstModernNames!).ToList();
                    firstName = joinedNames[rand.Next(joinedNames.Count)];
                }
                else if (genderComboBox.SelectedItem == femaleCbi)
                {
                    var joinedNames = femaleFirstModernNames!.Concat(neutralFirstModernNames!).ToList();
                    firstName = joinedNames[rand.Next(joinedNames.Count)];
                }
                else if (genderComboBox.SelectedItem == neutralCbi)
                {
                    firstName = neutralFirstModernNames![rand.Next(neutralFirstModernNames.Count)];
                }
                else if (genderComboBox.SelectedItem == anyCbi)
                {
                    var allNames = maleFirstModernNames!.Concat(femaleFirstModernNames!).Concat(neutralFirstModernNames!).ToList();
                    firstName = allNames[rand.Next(allNames.Count)];
                }
                nameTextBox.Text = $"{firstName} {lastName}";
            }
            else if (typeComboBox.SelectedItem == fantasyPlaceCbi)
            {
                Random rand = new Random();
                nameTextBox.Text = fantasyPlaceNames?[rand.Next(fantasyPlaceNames.Count)];
            }
            else if (typeComboBox.SelectedItem == scifiPlaceCbi)
            {
                Random rand = new Random();
                nameTextBox.Text = scifiPlaceNames?[rand.Next(scifiPlaceNames.Count)];
            }
            else if (typeComboBox.SelectedItem == modernPlaceCbi)
            {
                Random rand = new Random();
                nameTextBox.Text = modernPlaceNames?[rand.Next(modernPlaceNames.Count)];
            }
            else if (typeComboBox.SelectedItem == monsterCbi)
            {
                Random rand = new Random();
                nameTextBox.Text = monsterNames?[rand.Next(monsterNames.Count)];
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
            List<string> errors = new List<string>();
            string[] files =
            {
                "fantasy_epithets.txt",
                "fantasy_place_names.txt",
                "female_fantasy_first_names.txt",
                "female_modern_first_names.txt",
                "male_fantasy_first_names.txt",
                "male_modern_first_names.txt",
                "modern_place_names.txt",
                "modern_surnames.txt",
                "monster_names.txt",
                "neutral_fantasy_first_names.txt",
                "neutral_modern_first_names.txt",
                "scifi_place_names.txt"
            };

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    var loadedNames = ReadNameFile(files[i]);
                    if (loadedNames != null && loadedNames.Count > 0)
                    {
                        switch (i)
                        {
                            case 0: fantasyEpithets = loadedNames; break;
                            case 1: fantasyPlaceNames = loadedNames; break;
                            case 2: femaleFirstFantasyNames = loadedNames; break;
                            case 3: femaleFirstModernNames = loadedNames; break;
                            case 4: maleFirstFantasyNames = loadedNames; break;
                            case 5: maleFirstModernNames = loadedNames; break;
                            case 6: modernPlaceNames = loadedNames; break;
                            case 7: modernSurnames = loadedNames; break;
                            case 8: monsterNames = loadedNames; break;
                            case 9: neutralFirstFantasyNames = loadedNames; break;
                            case 10: neutralFirstModernNames = loadedNames; break;
                            case 11: scifiPlaceNames = loadedNames; break;
                        }
                    }
                    else
                    {
                        errors.Add(files[i]);
                    }
                }
                catch
                {
                    errors.Add(files[i]);
                }
            }

            if (errors.Count > 0)
            {
                MessageBox.Show(
                    $"Could not find {errors.Count} data file(s).\n\nCurrentDir: {Directory.GetCurrentDirectory()}\nBaseDir: {AppContext.BaseDirectory}\n\nMissing:\n{string.Join("\n", errors)}",
                    "Data files not found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private List<string>? ReadNameFile(string name)
        {
            string directory = Path.Combine(AppContext.BaseDirectory, "Random Names");

            string filePath = Path.Combine(directory, name);

            if (File.Exists(filePath)) { return File.ReadAllLines(filePath).ToList(); }
            else { return null; }
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("""
                
                This page allows you to generate random names for characters, places, and monsters for your RPG campaigns.
                
                Select the type of name you want to generate from the dropdown menu. For character names, you can also select a gender preference.

                Click the "Generate Name" button to create a random name based on your selections. The generated name will appear in the text box where you can edit it.

                If you want to save the generated name for future reference, click the "Add Memo" button. This will open a new memo window with the generated name pre-filled in the title.

                The pool of random names is sourced from text files located in the "Random Names" folder within the application's directory. You can customize these files to add your own names.
                
                """, "Name Generator Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
