using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using RPGUtility.Controls;

namespace RPGUtility
{
    public class SaveData
    {
        public List<(int Segments, string Name, int Filled)> ClocksData { get; set; } = new();
        public List<(string Name, int Value, Color BackgroundColour)> StatsData { get; set; } = new();
        public List<(string Title, string Content)> MemosData { get; set; } = new();
        public List<(int SessionNumber, string LogTitle, string SessionDescription)> SessionLogsData { get; set; } = new();
        public Dictionary<string, bool> TabsData { get; set; } = new Dictionary<string, bool>();
        public List<(string Name, int Initiative, int Hp, List<string> Conditions)> CombatantsData { get; set; } = new();
        public int CurrentTurnIndex { get; set; } = 0;
    }
}
