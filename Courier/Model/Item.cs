using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Model
{
    internal enum ItemType
    {
        Potion,
        Weapon,
        Armor
    }
    internal class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public double Value { get; set; }
        public string Icon { get; set; }

    }
}
