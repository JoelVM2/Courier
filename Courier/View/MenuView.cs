using Courier.Model;
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
        // Console.WriteLine("   ╭┳┳┳┳┳┳┳╮   \r\n   ┃╯╯╯╯╯╰╰┃   \r\n  ╭╋┳━┳━┳━┳╋╮  \r\n  ┃┓┃▇┃ ┃▇┃┏┃  \r\n  ╰╮╰━╯┊╰━╯╭╯  \r\n   ┃╱╰━━━╯╲┃   \r\n  ┏┫╰━━━━━╯┣┓  \r\n━━┫╰┓╲╰━╯╱┏╯┣━━");

        public static bool NewMision()
        {

            Console.Clear();
            Console.WriteLine("                                       NUEVA MISIÓN DISPONIBLE    ");
            Console.WriteLine("                                      ╔═══════════════════════╗");
            Console.WriteLine("                                      ║                       ║");
            Console.WriteLine("                                      ║       ╭┳┳┳┳┳┳┳╮       ║");
            Console.WriteLine("                                      ║       ┃╯╯╯╯╯╰╰┃       ║");
            Console.WriteLine("                                      ║      ╭╋┳━┳━┳━┳╋╮      ║");
            Console.WriteLine("                                      ║      ┃┓┃▇┃ ┃▇┃┏┃      ║");
            Console.WriteLine("                                      ║      ╰╮╰━╯┊╰━╯╭╯      ║");
            Console.WriteLine("                                      ║       ┃╱ ━━━ ╲┃       ║");
            Console.WriteLine("                                      ║      ┏┫ ━━━━━ ┣┓      ║");
            Console.WriteLine("                                      ║   ┏━━┫╰┓╲ ━ ╱┏╯┣━━┓   ║");
            Console.WriteLine("                                      ║   ┃               ┃   ║");
            Console.WriteLine("                                      ╠═══════════════════════╣");
            Console.WriteLine("                                      ║   ¿Estás preparado?   ║");
            Console.WriteLine("                                      ║ 1. Sí.                ║");
            Console.WriteLine("                                      ║ 2. No.                ║");
            Console.WriteLine("                                      ╚═══════════════════════╝");

            return Console.ReadLine() == "1";
        }

        // Al crear un nuevo personaje guardarlo en json de couriers
        public static int ShowClasses()
        {
            Console.WriteLine("                                      ╔════════════════════════════════╗");
            Console.WriteLine("                                      ║       CLASES DISPONIBLES       ║");
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

            return int.Parse(Console.ReadLine());
        }

        public static Player GetCourier(List<Player> couriers) 
        {
            Console.Clear();

            Console.WriteLine("                                      ╔════════════════════════════════╗");
            Console.WriteLine("                                      ║     COURIERS DISPONIBLES       ║");
            Console.WriteLine("                                      ╠════════════════════════════════╣");
            couriers.Select((c,i)=>new {Courier = c,Index = i}).ToList()
            .ForEach(x =>
            {
                var c = x.Courier;
                int i = x.Index;

                Console.WriteLine($"                                      ║ {i + 1}. {c.Class,-27} ║");
                Console.WriteLine($"                                      ║    Health: {c.Health,-16}    ║");
                Console.WriteLine($"                                      ║    Attack: {c.Attack,-16}    ║");
                Console.WriteLine($"                                      ║    Armor: {c.Armor,-17}    ║");
                Console.WriteLine($"                                      ║    EvadeChance: {c.EvadeChance}%{"",-7}     ║");
                Console.WriteLine($"                                      ║    HackSkill: {c.HackSkill}%{"",-8}      ║");
                Console.WriteLine($"                                      ║    CritChance: {c.CritChance}%{"",-8}     ║");
                Console.WriteLine($"                                      ║    Icon:{"",-22} ║");

                DrawIcon(c.Icon);

                if (i < couriers.Count - 1)
                    Console.WriteLine("                                      ╠════════════════════════════════╣");
                 
            });
            Console.WriteLine("                                      ╚════════════════════════════════╝");
            Console.WriteLine();
            Console.Write("                                      Selecciona una clase: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice)
                   || choice < 1
                   || choice > couriers.Count) ;

            return couriers[choice - 1];
        }

        private static void DrawIcon(string icon)
        {
            icon
                .Split('\n')
                .ToList()
                .ForEach(line =>
                    Console.WriteLine($"                                      ║      {line,-26}║")
                );
        }
        public static void ShowDeath()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("           HAS MUERTO             ");
            Console.WriteLine("=================================");
            Console.WriteLine("\nPulsa ENTER para volver al menú");
            Console.ReadLine();
        }

        public static void ShowVictory()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("      PAQUETE ENTREGADO           ");
            Console.WriteLine("=================================");
            Console.WriteLine("\nPulsa ENTER para continuar");
            Console.ReadLine();
        }

    }
}
