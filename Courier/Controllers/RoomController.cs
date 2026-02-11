using Courier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using static Courier.View.MenuView;

namespace Courier.Controllers
{
    internal class RoomController
    {
        private static readonly Random rnd = new Random();

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
            Room room;
            if (floor == 10)
            {
                var bossRooms = rooms.Where(r => r.Type.Equals("Boss")).ToList();
                room = bossRooms[rnd.Next(bossRooms.Count)];
            }
            else
            {
                do
                {
                    room = GetRandomRoom(rooms);
                } while (room.Type.Equals("Boss"));
            }

            player.CurrentRoom = floor;
            Console.Clear();
            ShowRoomHeader(player);
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

            if (player.CurrentHealth <= 0)
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

            double totalDamageDone = 0;
            var defeatedEnemies = new List<Enemy>();

            while (enemies.Any() && player.CurrentHealth > 0)
            {
                Console.Clear();
                ShowRoomHeader(player);
                Console.WriteLine(room.Icon);
                ShowEnemies(enemies);

                Enemy target = ChooseEnemy(enemies);

                double enemyInitialHealth = target.Health;
                GameController.FightEnemy(player, target);
                double damageDone = Math.Max(0, enemyInitialHealth - target.Health);
                totalDamageDone += damageDone;

                if (target.Health <= 0)
                {
                    defeatedEnemies.Add(target);
                    enemies.Remove(target);

                    Item drop = GameController.ScaleItem(
                        items.OrderBy(_ => rnd.Next()).First(), floor);

                    HandleDrop(drop, player);
                }

                if (player.CurrentHealth <= 0)
                {
                    ShowDeath();
                    return;
                }
            }

            Console.WriteLine("\n=== RESUMEN DE LA Planta ===");
            Console.WriteLine($"Daño total hecho: {totalDamageDone.ToGameFormat()}");

            if (defeatedEnemies.Any())
            {
                var groupByType = defeatedEnemies
                    .GroupBy(e => e.Type)
                    .Select(g => $"{g.Key}: {g.Count()}")
                    .ToList();

                Console.WriteLine("Enemigos derrotados por tipo:");
                groupByType.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("No derrotaste enemigos en esta sala.");
            }

            Console.WriteLine("\nPulsa ENTER para continuar...");
            Console.ReadLine();
        }


        private static void HandleDrop(Item item, Player player)
        {
            Console.WriteLine("\nBOTÍN ENCONTRADO:");
            Console.WriteLine($"{item.Icon} {item.Name} (+{item.Value})");

            switch (item.Type)
            {
                case ItemType.Potion:
                    player.CurrentHealth += item.Value;
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

                Console.WriteLine("Equipado correctamente");
            }
            else
            {
                Console.WriteLine("Lo dejas en el suelo");
            }
        }

        private static List<Enemy> GenerateRoomEnemies(Room room, int floor)
        { 
            var baseEnemies = GameController.GetGameData<Enemy>("Enemies.json");
            var enemies = new List<Enemy>();

            double roomMultiplier = 1 + floor * 0.1;

            if (room.Type.Equals("Boss"))
            {
                var boss = GameController.ScaleEnemy(
                    baseEnemies.OrderBy(e => rnd.Next()).First(),
                    floor
                );

                boss.Health = (int)(boss.Health * roomMultiplier);
                boss.Attack = (int)(boss.Attack * roomMultiplier);
                boss.Armor = (int)(boss.Armor * roomMultiplier);

                boss.Health *= 3;
                boss.Attack *= 3;
                boss.Armor *= 3;

                enemies.Add(boss);

                var extra = GameController.ScaleEnemy(
                    baseEnemies.OrderBy(e => rnd.Next()).First(), floor);

                extra.Health = (int)(extra.Health * roomMultiplier);
                extra.Attack = (int)(extra.Attack * roomMultiplier);
                extra.Armor = (int)(extra.Armor * roomMultiplier);

                enemies.Add(extra);
            }
            else
            {
                enemies.AddRange(
                    Enumerable.Range(0, room.EnemyCount)
                        .Select(_ =>
                        {
                            var e = GameController.ScaleEnemy(
                                baseEnemies.OrderBy(x => rnd.Next()).First(), floor);
                            e.Health = (int)(e.Health * roomMultiplier);
                            e.Attack = (int)(e.Attack * roomMultiplier);
                            e.Armor = (int)(e.Armor * roomMultiplier);
                            return e;
                        })
                        .ToList()
                );
            }

            return enemies;
        }


        private static void ShowEnemies(List<Enemy> enemies)
        {
            enemies
                .OrderByDescending(e => e.Health)
                .Select((e, i) => $"{i + 1}. {e.Name} | HP: {e.Health.ToGameFormat()} | ATK: {e.Attack.ToGameFormat()}")
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
            ShowRoomHeader(player);

            Console.WriteLine("                     ╔════════════════════════════╗");
            Console.WriteLine("                     ║   SISTEMA BLOQUEADO        ║");
            Console.WriteLine("                     ╠════════════════════════════╣");
            Console.WriteLine($"                     ║   ESCRIBE: {word,-10}     ║");
            Console.WriteLine("                     ║   TIEMPO: 4 SEGUNDOS       ║");
            Console.WriteLine("                     ╚════════════════════════════╝");
            Console.Write("\n> ");

            var start = DateTime.Now;
            string input = Console.ReadLine()
                ?.Trim()
                .ToUpperInvariant();
            double elapsed = (DateTime.Now - start).TotalSeconds;
            double allowedTime = 4 + (player.HackSkill / 100.0);
            if (elapsed <= allowedTime && input == word)
            {
                Console.WriteLine("ACCESO CONCEDIDO");
                Console.ReadLine();
                return true;
            }

            ApplyPenalty(player, 0.1, "ACCESO DENEGADO");
            Console.ReadLine();
            return false;
        }

        private static bool ResolvePuzzleRoom(Player player, int floor)
        {
            Random rnd = new Random();

            int maxValue = Math.Min(100, 200 + floor * 100);
            int a = rnd.Next(0, maxValue);
            int b = rnd.Next(0, maxValue);

            bool isSum = rnd.Next(2) == 0;

            int correctResult = isSum ? a + b : a - b;

            if (!isSum && correctResult < 0)
            {
                (a, b) = (b, a);
                correctResult = a - b;
            }

            Console.Clear();
            ShowRoomHeader(player);

            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║      PANEL DE SEGURIDAD    ║");
            Console.WriteLine("╠════════════════════════════╣");
            Console.WriteLine($"║   RESUELVE:               ║");
            Console.WriteLine($"║   {a} {(isSum ? "+" : "-")} {b} = ?{"",-8}    ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.Write("\n> ");

            double baseTime = 6;
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
            ApplyPenalty(player, 0.15, "Descarga eléctrica");
            Console.ReadLine();
            return false;
        }

        private static void ApplyPenalty(Player player, double percentage, string penaltyName)
        {
            double damage = Math.Max(1, player.CurrentHealth * percentage);
            player.CurrentHealth -= damage;

            Console.WriteLine($"{penaltyName}: -{damage.ToGameFormat()} de vida");
        }
    }
}
