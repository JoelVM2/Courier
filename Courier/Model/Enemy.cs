using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Model
{
    internal class Enemy
    {
        public class Enemigo
        {
            public string Name { get; set; }
            public double Health { get; set; }
            public double Attack { get; set; }
            public double Armor { get; set; }

            public string Type { get; set; }
            public string Icon { get; set; }
        }
    }
}
