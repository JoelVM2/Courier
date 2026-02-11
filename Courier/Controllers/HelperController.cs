using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.Controllers
{
    public static class HelperController
    {
        public static string ToGameFormat(this double value)
        {
            return value.ToString("0.##");
        }

        public static string ToGameFormat(this int value)
        {
            return value.ToString();
        }
    }
}
