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
        List<string> maleFirstModernNames = new List<string>()
        {
            "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Charles", "Thomas",
            "Christopher", "Daniel", "Matthew", "Anthony", "Mark", "Donald", "Steven", "Paul", "Andrew", "Joshua",
            "Kenneth", "Kevin", "Brian", "George", "Edward", "Ronald", "Timothy", "Jason", "Jeffrey", "Ryan",
            "Jacob", "Gary", "Nicholas", "Eric", "Stephen", "Jonathan", "Larry", "Justin", "Scott", "Brandon",
            "Benjamin", "Samuel", "Gregory", "Frank", "Alexander", "Raymond", "Patrick", "Jack",
            "Dennis", "Jerry", "Tyler", "Aaron", "Jose", "Henry", "Adam", "Douglas", "Nathan", "Peter",
            "Zachary", "Kyle", "Walter", "Harold", "Jeremy", "Ethan", "Carl", "Keith", "Roger", "Gerald",
            "Christian", "Terry", "Sean", "Arthur", "Austin", "Noah", "Jesse", "Joe", "Bryan", "Billy",
            "Jordan", "Albert", "Dylan", "Bruce", "Willie", "Gabriel", "Alan", "Juan", "Logan", "Wayne",
            "Ralph", "Roy", "Eugene", "Randy", "Vincent", "Russell", "Louis", "Philip", "Bobby", "Johnny", "Bradley",
            "Tim", "Chandler", "Daveed"
        };
        List<string> femaleFirstModernNames = new List<string>()
        {
            "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Barbara", "Susan", "Jessica", "Sarah", "Karen",
            "Nancy", "Margaret", "Lisa", "Betty", "Dorothy", "Sandra", "Ashley", "Kimberly", "Donna", "Emily",
            "Michelle", "Carol", "Amanda", "Melissa", "Deborah", "Stephanie", "Rebecca", "Sharon", "Laura", "Cynthia",
            "Kathleen", "Amy", "Shirley", "Angela", "Helen", "Anna", "Brenda", "Pamela", "Nicole", "Emma",
            "Samantha", "Katherine", "Christine", "Debra", "Rachel", "Catherine", "Carolyn", "Janet",
            "Ruth", "Maria", "Heather", "Diane", "Virginia", "Julie", "Joyce", "Victoria", "Olivia",
            "Kelly", "Christina", "Lauren", "Joan", "Evelyn", "Judith", "Megan", "Cheryl",
            "Andrea", "Hannah","Jacqueline","Martha","Gloria","Teresa","Ann","Sara","Madison","Frances",
            "Kathryn","Janice","Jean","Abigail","Alice","Julia","Judy","Sophia","Grace","Denise","Amber",
            "Doris","Marilyn","Danielle","Beverly","Isabella","Theresa","Diana","Natalie","Brittany",
            "Charlotte","Marie","Kayla","Alexis","Lori"
        };
        List<string> neutralFirstModernNames = new List<string>()
        {
            "Taylor", "Jordan", "Morgan", "Casey", "Riley", "Cameron", "Avery", "Quinn", "Reese", "Peyton",
            "Alex", "Charlie", "Dakota", "Emerson", "Finley", "Hayden", "Jaden", "Kai", "Logan", "Micah",
            "Parker", "Rowan", "Sawyer", "Skyler", "Tatum", "Blake", "Elliot", "Harper", "Justice", "Kendall",
            "Lane", "Marley", "River", "Sage", "Shiloh", "Terry", "Valentine",
            "Adrian", "Ariel", "Cruz", "Dallas", "Emery", "Frankie", "Indigo", "Jules",
            "Lennon", "Marlowe", "Nico", "Oakley", "Remy", "Sloane"
        };
        List<string> modernSurnames = new List<string>()
        {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
            "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
            "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
            "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter",
            "Roberts", "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cruz", "Edwards",
            "Collins",  "Reyes","Stewart","Morris","Morales","Murphy","Cook","Rogers","Gutierrez","Ortiz",
            "Morgan","Cooper","Peterson","Bailey","Reed","Kelly","Howard","Ramos","Kim","Cox","Ward",
            "Richardson","Watson","Brooks","Chavez","Wood","James","Bennett","Gray","Mendoza","Ruiz",
            "Hughes","Price","Alvarez","Castillo","Sanders","Patel","Myers", "Long","Ross","Foster","Jimenez",
            "Powell","Jenkins","Perry","Russell","Sullivan","Bell","Coleman","Butler","Henderson","Barnes","Gonzales", "Laurent",
            "Herforth", "Kreiger", "Lemieux", "Marchand", "Moreau", "Ouellet", "Pelletier", "Renaud", "Tremblay",
            "Aldridge"
        };
        List<string> fantasyPlaceNames = new List<string>()
        {
            "Eldoria", "Mysthaven", "Dragonspire", "Shadowfen", "Silverwood", "Stormhold", "Frostvale", "Ironpeak", "Moonshade", "Sunfire",
            "Duskmoor", "Brightwater", "Thornfield", "Ravencrest", "Windrider", "Emberfall", "Crystalbrook", "Starfall", "Oakenshield", "Wolfpine",
            "Ashenvale", "Blackrock", "Goldshire", "Highgarden", "Kingslanding", "Winterfell", "Riverrun", "Storm's End", "Dragonstone",
            "Valyria", "Braavos", "Pentos", "Qarth", "Meereen", "Yunkai", "Astapor", "Lorath", "Volantis", "Tarth", "Dorne",
            "Skyrim", "Whiterun", "Riften", "Solitude", "Windhelm", "Markarth", "Falkreath", "Dawnstar", "Morthal", "Winterhold",
            "Helgen", "Riverwood", "Ivarstead", "Kynesgrove", "Shor's Stone", "Falkreath Hold", "The Pale", "The Reach", "The Rift",
            "The Stormlands", "The Westerlands", "The Vale", "The Crownlands", "The North", "The Riverlands", "The Iron Islands",
            "The Dreadlands", "The Shadowlands", "The Sunken Lands", "The Crystal Isles", "The Emerald Forest", "The Sapphire Lake",
            "The Ruby Mountains", "The Obsidian Desert", "The Amethyst Caves", "The Topaz Plains", "The Diamond Cliffs", "The Onyx Hills",
            "The Pearl Coast", "The Jade Jungle", "The Turquoise Tundra", "The Garnet Glade", "The Citrine Canyon", "The Aquamarine Archipelago",
            "The Opal Oasis", "The Lapis Lagoon", "The Moonstone Marsh", "The Sunstone Savannah", "The Starstone Steppe", "The Bloodstone Bay",
            "The Thunderstone Thicket", "The Firestone Fjord", "The Earthstone Expanse", "The Windstone Wasteland", "The Icestone Isle",
            "The Lightstone Lair", "The Darkstone Domain", "The Spiritstone Sanctuary", "The Dreamstone Dominion", "The Shadowstone Stronghold",
            "The Froststone Fortress", "The Stormstone Spire", "The Flamestone Field", "The Rockstone Ridge", "The Sandstone Shore", "The Claystone Cliff", "The Mudstone Marsh",
            "The Limestone Lagoon", "The Sandstone Savannah", "The Chalkstone Canyon", "The Basalt Bay", "The Granite Grove", "The Marble Mountain",
            "Atlantis", "El Dorado", "Shangri-La", "Avalon", "Camelot", "Zion", "Utopia", "Elysium", "Nirvana", "Valhalla"
        };
        List<string> scifiPlaceNames = new List<string>()
        {
            "Nova Prime", "Zeta-5", "Orion's Belt", "Alpha Centauri", "Vega Station", "Nebula-9", "Galactic Hub", "Stellar Outpost", "Cosmos Colony", "Lunar Base",
            "Mars Colony", "Titan Station", "Europa Outpost", "Andromeda Station", "Pegasus Base", "Sirius-3", "Proxima Centauri", "Kepler-22b", "Trappist-1e", "Wolf 1061c",
            "Epsilon Eridani", "Tau Ceti", "Gliese 581g", "HD 40307g", "55 Cancri e", "GJ 1214b", "LHS 1140b", "K2-18b", "Ross 128b", "Kapteyn b",
            "PSR B1257+12 A", "PSR B1257+12 B", "PSR B1257+12 C", "OGLE-2005-BLG-390Lb", "MOA-2007-BLG-192Lb",
            "Xenon Prime", "Zypherion", "Quantarus", "Nebulon V", "Starlight Haven", "Celestia", "Astralis", "Luminara", "Galaxia", "Cosmica",
            "Nebuloria", "Stellaris", "Orbitus", "Lunaris", "Martianis", "Titanis", "Europis", "Andromedis", "Pegasusia", "Siriusia",
            "Proximia", "Kepleria", "Trappistia", "Wolfera", "Epsilonia", "Tautia", "Gliesia", "HD 40307ia", "55 Cancria", "GJ 1214ia", "LHS 1140ia",
            "K2-18ia", "Rossia", "Kapteynia", "PSR B1257+12 Aia", "PSR B1257+12 Bia", "PSR B1257+12 Cia", "OGLE-2005-BLG-390Lia", "MOA-2007-BLG-192Lia",
            "Nebulon Prime", "Zypheria", "Quantarus V", "Nebulon VI", "Starlight Citadel", "Celestia Nova", "Astralis Prime", "Luminara Station", "Galaxia Outpost", "Cosmica Base",
            "Nebuloria Prime", "Stellaris V", "Orbitus VI", "Lunaris Citadel", "Martianis Nova", "Titanis Station", "Europis Outpost", "Andromedis Base", "Pegasusia Prime", "Siriusia V",
            "Proximia VI", "Kepleria Citadel", "Trappistia Nova", "Wolfera Station", "Epsilonia Outpost", "Tautia Base",
            "Gliesia Prime", "HD 40307ia V", "55 Cancria VI", "GJ 1214ia Citadel", "LHS 1140ia Nova", "K2-18ia Station", "Rossia Outpost", "Kapteynia Base"
        };
        List<string> modernPlaceNames = new List<string>()
        {
            "Springfield", "Riverside", "Greenville", "Fairview", "Madison", "Georgetown", "Arlington", "Ashland", "Clinton", "Franklin",
            "Salem", "Bristol", "Milton", "Oakland", "Winchester", "Lexington", "Manchester", "Cleveland", "Dayton", "Hudson",
            "Kingston", "Lancaster", "Marion", "Newport", "Oxford", "Portland", "Richmond", "Shelby", "Trenton", "Windsor",
            "Albany", "Burlington", "Cambridge", "Dover", "Edison", "Fayetteville", "Hamilton", "Jefferson", "Lincoln",
            "Montgomery",  "Newton","Plymouth","Quincy","Raleigh","Somerset","Troy","Union","Vernon","Watertown",
            "York","Zanesville","Anderson","Bloomington","Columbus","Danville","Eugene","Florence","Glendale","Harrison",
            "Irvine","Jacksonville","Kalamazoo","Lafayette","Madisonville","Naperville","Orlando","Pensacola","Quakertown",
            "Rochester","Sarasota","Tallahassee","Urbana","Valdosta","Waco","Xenia","Ypsilanti", "Zephyrhills",
            "Cedarville", "Mapleton", "Oakridge", "Pinehurst", "Riverdale", "Silverlake", "Springdale", "Woodland", "Brookfield", "Clearwater",
            "Fairfield", "Hillside", "Lakeside", "Meadowbrook", "Pleasantville", "Riverview", "Sunnyvale", "Westfield", "Brighton", "Crestwood",
            "Edgewood", "Greenfield", "Highland", "Kingston", "Lakewood", "Millbrook", "Northfield", "Parkview", "Quarryville", "Rosewood",
            "Stonebridge", "Tranquil", "Valleyview", "Westwood", "Ashford", "Bayside", "Claremont", "Dunwood", "Elmwood", "Foxborough",
            "Glenwood", "Hawthorne", "Ivywood", "Juniper", "Kensington", "Lindenwood", "Maplewood", "Norwood", "Orchard", "Pinewood",
            "Quinlan", "Redwood", "Silverton", "Tanglewood", "Upton", "Violet", "Willowbrook", "Yorktown", "Zion",
            "Carthage", "Dublin", "Eden", "Fulton", "Granite", "Hampton", "Independence", "Junction", "Kingman", "Liberty"
        };
        List<string> monsterNames = new List<string>()
        {
            "Elzar", "Gorath", "Thalor", "Zyrix", "Vornak", "Kragoth", "Mordak", "Xalor", "Draxxis", "Zarnok", "Grimlok",
            "Fangor", "Ravok", "Tyrak", "Vexor", "Zoltar", "Karnath", "Dreadmaw", "Skulldrak", "Bloodfang",
            "Ironclaw", "Shadowfang", "Stormbringer", "Nightstalker", "Bonecrusher", "Firefang", "Venomtail", "Darkscale", "Frostbite", "Thunderclaw",
            "Gloomfang", "Razorwing", "Doomclaw", "Blightfang", "Graveclaw", "Hellfire", "Icefang", "Stormfang", "Venomclaw",
            "Zerath", "Kragor", "Mordek", "Xalax", "Draxor", "Zarnak", "Grimtor", "Fangor", "Ravok", "Tyrak", "Vexor", "Zoltar", "Karnath",
            "Dreadmaw", "Skulldrak", "Bloodfang", "Jinglebax", "Duocerinx", "Fluffernox", "Glimmerpaw", "Hootenclaw", "Nuzzlefang", "Puffertail", "Snickerbax",
            "Wobbleclaw", "Zazzlepaw", "Bumblefang", "Cuddleclaw", "Dazzlepaw", "Fuzzlefang", "Giggleclaw", "Hugglepaw", "Jollybax", "Kuddleclaw",
            "Duaserrahsix", "Flufferwump", "Glimmerpuff", "Hootenwhisk", "Nuzzletuft", "Puffernose", "Snickerwhisk", "Wobblepuff", "Zazzlewhisk",
            "Bumblepuff", "Cuddlewhisk", "Dazzlewhisk", "Fuzzlepuff", "Gigglewhisk", "Hugglepuff", "Jollywhisk", "Kuddlewhisk", "Snugglepuff",
            "Deathbringer", "Soulreaper", "Doomsayer", "Gravewalker", "Nightbane", "Bloodreaver", "Shadowmourn", "Frostmourne", "Hellraiser", "Darkbane",
            "Bonegnasher", "Firestorm", "Venomspike", "Stormrage", "Thunderfury", "Icehowl", "Doomhammer", "Skullcrusher", "Ironbane", "Blightbringer",
            "Gloomreaper", "Razorclaw", "Dreadfang", "Gravefang", "Hellfang", "Icefang", "Stormfang", "Venomfang", "Zerath"
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
