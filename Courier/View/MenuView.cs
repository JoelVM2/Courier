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
            Console.WriteLine("                            ██████╗ ██████╗ ██╗   ██╗██████╗ ██╗███████╗██████╗ \r\n                           ██╔════╝██╔═══██╗██║   ██║██╔══██╗██║██╔════╝██╔══██╗\r\n                           ██║     ██║   ██║██║   ██║██████╔╝██║█████╗  ██████╔╝\r\n                           ██║     ██║   ██║██║   ██║██╔══██╗██║██╔══╝  ██╔══██╗\r\n                           ╚██████╗╚██████╔╝╚██████╔╝██║  ██║██║███████╗██║  ██║\r\n                            ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝╚══════╝╚═╝  ╚═╝\r\n\r\n                                     Presiona ENTER para comenzar\r\n");
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("                                      ╔════════════════════════╗");
            Console.WriteLine("                                      ║        COURIER         ║");
            Console.WriteLine("                                      ╠════════════════════════╣");
            Console.WriteLine("                                      ║ 1. Cargar Partida      ║");
            Console.WriteLine("                                      ║ 2. Nueva Partida       ║");
            Console.WriteLine("                                      ║ 3. Salir               ║");
            Console.WriteLine("                                      ╚════════════════════════╝");
            Console.WriteLine();
            Console.Write("                                      Selecciona una opción: ");

        }

        public static void ShowClasses()
        {
            Console.WriteLine("                                      ╔════════════════════════════════╗");
            Console.WriteLine("                                      ║          CLASES DISPONIBLES    ║");
            Console.WriteLine("                                      ╠════════════════════════════════╣");

            Console.WriteLine("                                      ║ 1. Runner                      ║");
            Console.WriteLine("                                      ║    Health: 10                  ║");
            Console.WriteLine("                                      ║    Attack: 3                   ║");
            Console.WriteLine("                                      ║    Armor: 1                    ║");
            Console.WriteLine("                                      ║    EvadeChance: 50%            ║");
            Console.WriteLine("                                      ║    HackSkill: 40%              ║");
            Console.WriteLine("                                      ║    Icon:                       ║");
            Console.WriteLine("                                      ║      o                         ║");
            Console.WriteLine("                                      ║     /|>                        ║");
            Console.WriteLine("                                      ║     / \\                        ║");
            Console.WriteLine("                                      ╠════════════════════════════════╣");

            Console.WriteLine("                                      ║ 2. Hacker                      ║");
            Console.WriteLine("                                      ║    Health: 8                   ║");
            Console.WriteLine("                                      ║    Attack: 2                   ║");
            Console.WriteLine("                                      ║    Armor: 1                    ║");
            Console.WriteLine("                                      ║    EvadeChance: 60%            ║");
            Console.WriteLine("                                      ║    HackSkill: 60%              ║");
            Console.WriteLine("                                      ║    Icon:                       ║");
            Console.WriteLine("                                      ║     [o]                        ║");
            Console.WriteLine("                                      ║     /|\\                        ║");
            Console.WriteLine("                                      ║     / \\                        ║");
            Console.WriteLine("                                      ╠════════════════════════════════╣");

            Console.WriteLine("                                      ║ 3. Tank                        ║");
            Console.WriteLine("                                      ║    Health: 12                  ║");
            Console.WriteLine("                                      ║    Attack: 4                   ║");
            Console.WriteLine("                                      ║    Armor: 2                    ║");
            Console.WriteLine("                                      ║    EvadeChance: 30%            ║");
            Console.WriteLine("                                      ║    HackSkill: 20%              ║");
            Console.WriteLine("                                      ║    Icon:                       ║");
            Console.WriteLine("                                      ║     [O]                        ║");
            Console.WriteLine("                                      ║     /█\\                        ║");
            Console.WriteLine("                                      ║     / \\                        ║");
            Console.WriteLine("                                      ╚════════════════════════════════╝");

            Console.WriteLine();
            Console.Write("                                      Selecciona una clase: ");
            Console.ReadLine();
        }


    }
}
