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
            List<string> errors = new List<string>();

            try
            {
                fantasyEpithets = ReadNameFile("fantasy_epithets.txt");
            }
            catch
            { errors.Add("fantasy_epithets.txt"); }
            try             
            {
                fantasyPlaceNames = ReadNameFile("fantasy_place_names.txt");
            }
            catch { errors.Add("fantasy_place_names.txt"); }
            try
            {
                femaleFirstFantasyNames = ReadNameFile("female_fantasy_first_names.txt");
            }
            catch
            { errors.Add("female_fantasy_first_names.txt"); }
            try
            {
                femaleFirstModernNames = ReadNameFile("female_modern_first_names.txt");
            }
            catch { errors.Add("female_modern_first_names.txt"); }
            try
            {
                maleFirstFantasyNames = ReadNameFile("male_fantasy_first_names.txt");
            }
            catch { errors.Add("male_first_fantasy_names.txt"); }
            try
            {
                maleFirstModernNames = ReadNameFile("male_modern_first_names.txt");
            }
            catch
            {
                errors.Add("male_modern_first_names.txt");
            }
            try             
            {
                modernPlaceNames = ReadNameFile("modern_place_names.txt");
            }
            catch { errors.Add("modern_place_names.txt"); }
            try             
            {
                modernSurnames = ReadNameFile("modern_surnames.txt");
            }
            catch { errors.Add("modern_surnames.txt"); }
            try             
            {
                monsterNames = ReadNameFile("monster_names.txt");
            }
            catch { errors.Add("monster_names.txt"); }
            try
            {
                neutralFirstFantasyNames = ReadNameFile("neutral_fantasy_first_names.txt");
            }
            catch
            { errors.Add("neutral_fantasy_first_names.txt"); }
            try             
            {
                neutralFirstModernNames = ReadNameFile("neutral_modern_first_names.txt");
            }
            catch { errors.Add("neutral_modern_first_names.txt"); }
            try             
            {
                scifiPlaceNames = ReadNameFile("scifi_place_names.txt");
            }
            catch { errors.Add("scifi_place_names.txt"); }

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
