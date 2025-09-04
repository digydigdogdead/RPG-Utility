using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtility
{
    public class Combatant
    {
        public int TurnOrder { get; set; } = 0;
        public string Name { get; set; } = "New Combatant";
        public int Initiative { get; set; } = 0;
    }
}
