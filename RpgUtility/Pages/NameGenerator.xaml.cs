
using System.Windows;
using System.Windows.Controls;


namespace RPGUtility.Pages
{
    /// <summary>
    /// Interaction logic for NameGenerator.xaml
    /// </summary>
    public partial class NameGenerator : Page
    {
        List<string> maleFirstFantasyNames = new List<string>()
        {
            
        };

        List<string> neutralFirstFantasyNames = new List<string>()
        {
            
        };

        List<string> femaleFirstFantasyNames = new List<string>()
        {
            
        };

        List<string> fantasyEpithets = new List<string>()
        {
            
        };
        List<string> maleFirstModernNames = new List<string>()
        {
            
        };
        List<string> femaleFirstModernNames = new List<string>()
        {
            
        };
        List<string> neutralFirstModernNames = new List<string>()
        {
           
        };
        List<string> modernSurnames = new List<string>()
        {
            
        };
        List<string> fantasyPlaceNames = new List<string>()
        {
            
        };
        List<string> scifiPlaceNames = new List<string>()
        {
            
        };
        List<string> modernPlaceNames = new List<string>()
        {
            
        };
        List<string> monsterNames = new List<string>()
        {
            
        };
        public NameGenerator()
        {
            InitializeComponent();
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
    }
}
