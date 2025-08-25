using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Controls;

namespace RPGUtility
{
    class SaveData
    {
        public Stack<string> RollHistory { get; set; } = new Stack<string>();
        public List<(int Segments, string Name)> ClocksData { get; set; } = new List<(int Segments, string Name)>();
        public List<(string Name, int Value)> StatsData { get; set; } = new List<(string Name, int Value)>();
        public List<(string Title, string Content)> MemosData { get; set; } = new List<(string Title, string Content)>();
        public List<(int SessionNumber, string LogTitle, string SessionDescription)> SessionLogsData { get; set; } = new List<(int SessionNumber, string LogTitle, string SessionDescription)>();
    }
}
