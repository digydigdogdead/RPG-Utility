using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGUtility.Controls;

namespace RPGUtility
{
    public class SaveData
    {
        public List<(int Segments, string Name, int Filled)> ClocksData { get; set; } = new List<(int Segments, string Name, int Filled)>();
        public List<(string Name, int Value)> StatsData { get; set; } = new List<(string Name, int Value)>();
        public List<(string Title, string Content)> MemosData { get; set; } = new List<(string Title, string Content)>();
        public List<(int SessionNumber, string LogTitle, string SessionDescription)> SessionLogsData { get; set; } = new List<(int SessionNumber, string LogTitle, string SessionDescription)>();
        public Dictionary<string, bool> TabsData { get; set; } = new Dictionary<string, bool>();
        public List<Combatant> CombatantsData { get; set; } = new List<Combatant>();
        public int CurrentTurnIndex { get; set; } = 0;
    }
}
