using System;
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
    /// Interaction logic for NameGenerator.xaml
    /// </summary>
    public partial class NameGenerator : Page
    {
        List<string> maleFirstFantasyNames = new List<string>()
        {
            "Arin", "Borin", "Cedric", "Dain", "Eldric", "Farin", "Gorin", "Haldor", "Ivor", "Jareth", "Korin", "Loric", "Marek", "Nolan", "Orin", "Perrin", "Quinlan", "Roderic", "Soren", "Theron",
            "Ulric", "Varek", "Wulfric", "Xander", "Yorick", "Zarek",
            "Eden", "Finn", "Galen", "Hale", "Jace", "Kade", "Liam", "Milo", "Nash", "Oren", "Reed", "Sage", "Tate", "Vance",
            "Zane", "Ash", "Cade", "Flynn", "Gray", "Jett", "Knox", "Leif", "Rhett", "Troy",
            "Zion", "Axel", "Cyrus", "Dante", "Ezra", "Jasper", "Kian", "Luca", "Maddox", "Orion", "Ryder", "Silas", "Talon", "Zayden",
            "Alaric", "Balthazar", "Cassian", "Dorian", "Evander", "Lucian", "Magnus", "Octavian", "Thaddeus", "Valerian",
            "Zephyr", "Aldric", "Brennan", "Caius", "Dashiell", "Ezekiel", "Leander", "Matthias", "Sullivan", "Theron",
            "Xavian", "Zander", "Archer", "Brennan", "Caspian"
        };

        List<string> neutralFirstFantasyNames = new List<string>()
        {
            "Bael", "Celes", "Dara", "Eira", "Fenn", "Gale", "Hale", "Ira", "Joss", "Kari", "Lior", "Mira", "Nia", "Orin", "Pax", "Quin", "Rae", "Sage",
            "Wren", "Zephyr", "Ashen", "Briar", "Cyan", "Ember", "Frost", "Glade", "Haven", "Indigo", "Jade", "Lark", "Nova", "Onyx", "Rune",
            "Skylar", "Vale", "Winter", "Zion", "Aeris", "Bryn", "Ciel", "Dusk", "Lioren", "Blaise", "Phoenix"
        };

        List<string> femaleFirstFantasyNames = new List<string>()
        {
            "Aria", "Brina", "Celia", "Dara", "Elara", "Fiona", "Gwen", "Helena", "Isla", "Jora", "Kira", "Luna", "Mira", "Nia", "Orla", "Phaedra", "Quilla", "Rhea", "Selene", "Thalia",
            "Una", "Vera", "Wynne", "Xara", "Yara", "Zara",
            "Ayla", "Bryn", "Cleo", "Daphne", "Eira", "Freya", "Gaia", "Hazel", "Ivy", "Juno", "Kaia", "Lila", "Maya", "Nora", "Opal", "Piper", "Quinn", "Raven",
            "Sage", "Tessa", "Violet",
            "Zoe", "Aurora", "Celeste", "Elowen", "Isolde", "Lyra", "Seraphina", "Thalassa",
            "Amara", "Bellatrix", "Calista", "Dahlia", "Evangeline", "Lysandra", "Melisande",
            "Valeria", 
            "Zinnia", "Ariel", "Tali", "Vesper", "Elysia", "Faye"
        };
        public NameGenerator()
        {
            InitializeComponent();
        }

        private void generateNameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addMemoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (genderComboBox == null) return;
            if (typeComboBox.SelectedItem == fantasyPlaceCbi 
                || typeComboBox.SelectedItem == modernPlaceCbi 
                || typeComboBox.SelectedItem == scifiPlaceCbi
                || typeComboBox.SelectedItem == monsterCbi)
            {
                genderComboBox.IsEnabled = false;
            }
            else genderComboBox.IsEnabled = true;
        }
    }
}
