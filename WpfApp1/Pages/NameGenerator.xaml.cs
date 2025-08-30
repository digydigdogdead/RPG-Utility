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

        List<string> fantasyEpithets = new List<string>()
        {
            "the Brave", "the Wise", "the Swift", "the Bold", "the Just", "the Fierce", "the Cunning", "the Valiant", "the Noble", "the Strong",
            "the Fearless", "the Merciful", "the Radiant", "the Resolute", "the Stalwart", "the Gallant", "the Mighty", "the Loyal",
            "the Protector", "the Wanderer", "the Seeker", "the Enchanter", "the Shadow", "the Flame", "the Storm", "the Guardian",
            "the Wanderer", "the Mystic", "the Alchemist", "the Sage", "the Herald", "the Champion", "the Conqueror", "the Liberator", "the Vanquisher",
            "the Justicar", "the Paladin", "the Warden", "the Sentinel", "the Crusader", "the Invincible", "the Unyielding",
            "the Indomitable", "the Resolute", "the Vengeful", "the Relentless", "the Fierceheart", "the Ironclad", "the Stormbringer",
            "the Lightbringer", "the Shadowbane", "the Dawnbringer", "the Nightstalker", "the Earthshaker", "the Skybreaker",
            "the Tidecaller", "the Unruly", "the Untamed", "the Wild", "the Savage", "the Ferocious", "the Beastmaster", "the Dragonborn",
            "the Phoenix", "the Griffin", "the Wyvern", "the Basilisk", "the Chimera", "the Hydra", "the Leviathan", "the Kraken",
            "the Serpent", "the Wyrm", "the Lich", "the Necromancer", "the Warlock", "the Sorcerer", "the Enchanter", "the Illusionist",
            "the Summoner", "the Elementalist", "the Druid", "the Shaman", "the Ranger", "the Hunter", "the Archer", "the Scout",
            "the Assassin", "the Thief", "the Rogue", "the Bard", "the Minstrel", "the Jester", "the Trickster", "the Alchemist",
            "the Inventor", "the Engineer", "the Tinkerer", "the Artificer", "the Smith", "the Blacksmith", "the Armorer", "the Fletcher",
            "the Cook", "the Brewer", "the Merchant", "the Trader", "the Sailor", "the Navigator", "the Captain", "the Admiral",
            "the Explorer", "the Pioneer", "the Pathfinder", "the Voyager", "the Nomad", "the Pilgrim", "the Seeker", "the Dreamer",
            "the Visionary", "the Prophet", "the Oracle", "the Seer", "the Mystic", "the Hermit", "the Recluse", "the Wanderer",
            "the Pilgrim", "the Sojourner", "the Traveler", "the Wayfarer", "the Adventurer", "the Hero", "the Legend", "the Myth", "the Fable"
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
            else
            {
                return;
            }
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
