using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.View
{
    internal class MenuView
    {

        public static void IntroMenu()
        {
            Console.Clear();
            Console.WriteLine(" ██████╗ ██████╗ ██╗   ██╗██████╗ ██╗███████╗██████╗ \r\n██╔════╝██╔═══██╗██║   ██║██╔══██╗██║██╔════╝██╔══██╗\r\n██║     ██║   ██║██║   ██║██████╔╝██║█████╗  ██████╔╝\r\n██║     ██║   ██║██║   ██║██╔══██╗██║██╔══╝  ██╔══██╗\r\n╚██████╗╚██████╔╝╚██████╔╝██║  ██║██║███████╗██║  ██║\r\n ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝╚══════╝╚═╝  ╚═╝\r\n\r\n                Presiona ENTER para comenzar\r\n");
        }

        public static void ShowMenu()
        {
           // Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║        COURIER         ║");
            Console.WriteLine("╠════════════════════════╣");
            Console.WriteLine("║ 1. Cargar Partida      ║");
            Console.WriteLine("║ 2. Nueva Partida       ║");
            Console.WriteLine("║ 3. Salir               ║");
            Console.WriteLine("╚════════════════════════╝");
            Console.WriteLine();
            Console.Write("Selecciona una opción: ");

        }

    }
}
