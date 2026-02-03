using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Courier.Model
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CourierClassEnum
    {
        Runner,
        Hacker,
        Tank
    }

    internal class Player
    {
        public string Name { get; set; }
        public CourierClassEnum Class { get; set; }
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
