using Courier.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Courier.Controllers
{
    internal class RoomController
    {
        private static readonly Random rnd = new Random();

        private static readonly List<int> PuzzleDigits = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static readonly List<char> PuzzleSymbols = new()
        {
            '▲', '■', '●', '◆', '★'
        };

        private static readonly List<string> PasswordWords = new()
        {
            "ACCESS",
            "COURIER",
            "DELIVERY",
            "SECURITY",
            "HACK",
            "PACKAGE",
            "SYSTEM",
            "OVERRIDE"
        };

        public static Room GetRandomRoom(List<Room> rooms) =>
            rooms.OrderBy(_ => rnd.Next()).First();

        public static void ResolveRoom(Player player, List<Room> rooms, int floor)
        {
            Room room = GetRandomRoom(rooms);
            player.CurrentRoom = floor;

            Console.Clear();
            Console.WriteLine(room.Icon);

            bool eventSuccess = true;

            switch (room.Type)
            {
                case "Puzzle":
                    eventSuccess = ResolvePuzzleRoom(player, floor);
                    break;

                case "Password":
                    eventSuccess = ResolvePasswordRoom(player);
                    break;
            }

            if (player.Health <= 0)
                return;

            if (room.EnemyCount > 0)
                ResolveEnemyRoom(room, player, floor, eventSuccess);
        }

        private static void ResolveEnemyRoom(Room room, Player player, int floor, bool eventSuccess)
        {
            var items = GameController.GetGameData<Item>("Items.json");

            List<Enemy> enemies = GenerateRoomEnemies(room, floor);

            if (!eventSuccess)
            {
                enemies.ForEach(e =>
                {
                    e.Health *= 1.2;
                    e.Attack *= 1.2;
                });
            }

            while (enemies.Any() && player.Health > 0)
            {
                Console.Clear();
                Console.WriteLine(room.Icon);
                ShowEnemies(enemies);

                Enemy target = ChooseEnemy(enemies);
                GameController.FightEnemy(player, target);

                if (player.Health <= 0)
                    return;

                Item drop = GameController.ScaleItem(
                    items.OrderBy(_ => rnd.Next()).First(), floor);

                HandleDrop(drop, player);
                enemies.Remove(target);

                Console.WriteLine("\nPulsa ENTER...");
                Console.ReadLine();
            }
        }

        private static void HandleDrop(Item item, Player player)
        {
            Console.WriteLine("\nBOTÍN ENCONTRADO:");
            Console.WriteLine($"{item.Icon} {item.Name} (+{item.Value})");

            switch (item.Type)
            {
                case ItemType.Potion:
                    player.Health += item.Value;
                    Console.WriteLine($"Te curas {item.Value} de vida");
                    break;

                case ItemType.Weapon:
                    EquipItem(item, player, isWeapon: true);
                    break;

                case ItemType.Armor:
                    EquipItem(item, player, isWeapon: false);
                    break;
            }

            Console.WriteLine("\nPulsa ENTER para continuar...");
            Console.ReadLine();
        }

        private static void EquipItem(Item item, Player player, bool isWeapon)
        {
            Item current = isWeapon ? player.EquippedWeapon : player.EquippedArmor;

            Console.WriteLine(current == null
                ? "No tienes nada equipado."
                : $"Actualmente equipado: {current.Name} (+{current.Value})");

            Console.WriteLine("¿Quieres equiparlo?");
            Console.WriteLine("1. Sí");
            Console.WriteLine("2. No");

            if (Console.ReadLine() == "1")
            {
                if (isWeapon)
                    player.EquippedWeapon = item;
                else
                    player.EquippedArmor = item;

                Console.WriteLine("✔ Equipado correctamente");
            }
            else
            {
                Console.WriteLine("❌ Lo dejas en el suelo");
            }
        }

        private static List<Enemy> GenerateRoomEnemies(Room room, int floor)
        {
            var baseEnemies = GameController.GetGameData<Enemy>("Enemies.json");

            return Enumerable.Range(0, room.EnemyCount)
                .Select(_ => GameController.ScaleEnemy(
                    baseEnemies.OrderBy(e => rnd.Next()).First(), floor))
                .ToList();
        }

        private static void ShowEnemies(List<Enemy> enemies)
        {
            enemies
                .Select((e, i) => $"{i + 1}. {e.Name} | HP: {e.Health} | ATK: {e.Attack}")
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static Enemy ChooseEnemy(List<Enemy> enemies)
        {
            int choice;

            do
            {
                Console.Write("\nElige enemigo: ");
            }
            while (!int.TryParse(Console.ReadLine(), out choice)
                   || choice < 1
                   || choice > enemies.Count);

            return enemies[choice - 1];
        }

        private static bool ResolvePasswordRoom(Player player)
        {
            string word = PasswordWords
                .OrderBy(_ => rnd.Next())
                .First()
                .ToUpperInvariant();

            Console.Clear();
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║   SISTEMA BLOQUEADO        ║");
            Console.WriteLine("╠════════════════════════════╣");
            Console.WriteLine($"║   ESCRIBE: {word,-10}   ║");
            Console.WriteLine("║   TIEMPO: 4 SEGUNDOS       ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.Write("\n> ");

            var start = DateTime.Now;
            string input = Console.ReadLine()
                ?.Trim()
                .ToUpperInvariant();
            double elapsed = (DateTime.Now - start).TotalSeconds;
            double allowedTime = 4 + (player.HackSkill / 100.0);
            if (elapsed <= allowedTime && input == word)
            {
                Console.WriteLine("✔ ACCESO CONCEDIDO");
                Console.ReadLine();
                return true;
            }

            Console.WriteLine("✖ ACCESO DENEGADO");
            ApplyPasswordPenalty(player);
            Console.ReadLine();
            return false;
        }

        private static void ApplyPasswordPenalty(Player player)
        {
            double damage = Math.Max(1, player.Health * 0.1);
            player.Health -= damage;

            Console.WriteLine($"Has recibido {damage} de daño por el fallo.");
        }

        private static bool ResolvePuzzleRoom(Player player, int floor)
        {
            Random rnd = new Random();

            int maxValue = Math.Min(2000, 200 + floor * 100);
            int a = rnd.Next(0, maxValue);
            int b = rnd.Next(0, maxValue);

            bool isSum = rnd.Next(2) == 0;

            int correctResult = isSum ? a + b : a - b;

            // Evitar negativos en resta
            if (!isSum && correctResult < 0)
            {
                (a, b) = (b, a);
                correctResult = a - b;
            }

            Console.Clear();
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║      PANEL DE SEGURIDAD    ║");
            Console.WriteLine("╠════════════════════════════╣");
            Console.WriteLine($"║   RESUELVE:               ║");
            Console.WriteLine($"║   {a} {(isSum ? "+" : "-")} {b} = ?{"",-8}║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.Write("\n> ");

            double baseTime = 3;
            double bonusTime = player.HackSkill / 50.0;
            double maxTime = baseTime + bonusTime;

            var start = DateTime.Now;
            string input = Console.ReadLine()?.Trim();
            double elapsed = (DateTime.Now - start).TotalSeconds;

            if (elapsed <= maxTime &&
                int.TryParse(input, out int result) &&
                result == correctResult)
            {
                Console.WriteLine("\nPANEL DESBLOQUEADO");
                Console.ReadLine();
                return true;
            }

            Console.WriteLine("\nERROR EN EL CÁLCULO");
            ApplyPuzzlePenalty(player);
            Console.ReadLine();
            return false;
        }

        private static void ApplyPuzzlePenalty(Player player)
        {
            double damage = Math.Max(1, player.Health * 0.15);
            player.Health -= damage;

            Console.WriteLine($"Descarga eléctrica: -{damage} de vida");
        }




    }
}
