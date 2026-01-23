using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Courier.Model.Enemy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Courier.Model
{
    internal class Room
    {
        public int Id { get; set; }
        public int EnemyCount { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
    }
}
