using Courier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Courier.Controllers.HelperController;
namespace Courier.View
{
    internal class MenuView
    {

        public static void IntroMenu()
        {
            Console.Clear();
            Console.WriteLine("\r\n\r\n\r\n\r\n                            ██████╗ ██████╗ ██╗   ██╗██████╗ ██╗███████╗██████╗ \r\n                           ██╔════╝██╔═══██╗██║   ██║██╔══██╗██║██╔════╝██╔══██╗\r\n                           ██║     ██║   ██║██║   ██║██████╔╝██║█████╗  ██████╔╝\r\n                           ██║     ██║   ██║██║   ██║██╔══██╗██║██╔══╝  ██╔══██╗\r\n                           ╚██████╗╚██████╔╝╚██████╔╝██║  ██║██║███████╗██║  ██║\r\n                            ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝╚══════╝╚═╝  ╚═╝\r\n\r\n                                     Presiona ENTER para comenzar\r\n");
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n                                      ╔════════════════════════╗");
            Console.WriteLine("                                      ║        COURIER         ║");
            Console.WriteLine("                                      ╠════════════════════════╣");
            Console.WriteLine("                                      ║ 1. Cargar Partida      ║");
            Console.WriteLine("                                      ║ 2. Nueva Partida       ║");
            Console.WriteLine("                                      ║ 3. Salir               ║");
            Console.WriteLine("                                      ╚════════════════════════╝");
            Console.WriteLine();
            Console.Write("                                      Selecciona una opción: ");

        }

        public static bool NewMision()
        {
            string opcion;

            do
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

                opcion = Console.ReadLine();

        } while (opcion != "1" && opcion != "2");

          return opcion == "1";
        }

     
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

            int choice;
            while (true)
            {
                Console.Write("                                      Selecciona una clase: ");
                string input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 3)
                    break;

                Console.WriteLine("Debes escribir un número entre 1 y 3.");
            }

            return choice;
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
                Console.WriteLine($"                                      ║    Health: {c.Health.ToGameFormat(),-16}    ║");
                Console.WriteLine($"                                      ║    Attack: {c.Attack.ToGameFormat(),-16}    ║");
                Console.WriteLine($"                                      ║    Armor: {c.Armor.ToGameFormat(),-17}    ║");
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
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > couriers.Count) ;

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

        public static void ShowVictory(int health, int attack, int armor)
        {

            Console.WriteLine("\n                =================================");
            Console.WriteLine("                      PAQUETE ENTREGADO           ");
            Console.WriteLine("                =================================");
            Console.WriteLine("                ¡Has recibido un bono por tu victoria!");
            Console.WriteLine($"                +{health} de vida");
            Console.WriteLine($"                +{attack} de ataque");
            Console.WriteLine($"                +{armor} de armadura");
            Console.WriteLine("\n                Pulsa ENTER para continuar...");
            Console.ReadLine();
        }

        public static void ShowRoomHeader(Player player)
        {
            Console.WriteLine($"                                ═════════ Planta {player.CurrentRoom} ═════════\n");
        }

        public static string GetCourierName()
        {
            Console.Clear();
            string name;

            do
            {
                Console.WriteLine("                     ═════════ Escoge un nombre para tu jugador ═════════\n");
                Console.Write("                     ▶ ");

                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("\n                   El nombre no puede estar vacío.\n");
                    Console.WriteLine("                     Presiona ENTER para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

    }
}
