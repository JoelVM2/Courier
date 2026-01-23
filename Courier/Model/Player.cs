using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Model
{
    internal class Player
    {
        public string Name { get; set; }
        public CourierClass Class { get; set; }
        public double Health { get; set; }
        public double Attack { get; set; }
        public double Armor { get; set; }
        public int CurrentRoom { get; set; }
        public int CurrentBuilding { get; set; }
        public bool HasPackage { get; set; }
        public double EvadeChance { get; set; }
        public double HackSkill { get; set; }
        public double CritChance { get; set; }
        public List<Item> Items { get; set; }
        public string Icon { get; set; }
    }

}
