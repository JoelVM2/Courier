using Courier.Model;
using System.Reflection;
using System.Text.Json;
using static Courier.View.MenuView;
using static Courier.Controllers.HelperController;
namespace Courier.Controllers
{
    internal class GameController
    {
        private static readonly Random rnd = new Random();

        public static List<T> GetGameData<T>(string jsonFileName)
        {
            string jsonPath = Path.GetFullPath(
                Path.Combine("..", "..", "..", "Data", jsonFileName));

            return File.Exists(jsonPath)
                ? JsonSerializer.Deserialize<List<T>>(File.ReadAllText(jsonPath)) ?? new List<T>()
                : throw new FileNotFoundException($"No se encontró el archivo: {jsonPath}");
        }

        public static double GetFloorMultiplier(int floor) =>
            1.0 + (floor - 1) * 0.15;

        public static Enemy ScaleEnemy(Enemy baseEnemy, int floor)
        {
            double mult = GetFloorMultiplier(floor);

            return new Enemy
            {
                Name = baseEnemy.Name,
                Type = baseEnemy.Type,
                Icon = baseEnemy.Icon,
                Health = Math.Round(baseEnemy.Health * mult, 1),
                Attack = Math.Round(baseEnemy.Attack * mult, 1),
                Armor = Math.Round(baseEnemy.Armor * mult, 1)
            };
        }

        public static Item ScaleItem(Item baseItem, int floor)
        {
            double mult = 1.0 + (floor - 1) * 0.10;

            return new Item
            {
                Name = baseItem.Name,
                Type = baseItem.Type,
                Icon = baseItem.Icon,
                Value = Math.Round(baseItem.Value * mult, 1)
            };
        }

        public static void FightEnemy(Player player, Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine($"COMBATE CONTRA {enemy.Name}\n");

            while (enemy.Health > 0 && player.CurrentHealth > 0)
            {
                double dmgToEnemy = Math.Max(1, player.TotalAttack - enemy.Armor);
                enemy.Health -= dmgToEnemy;

                Console.WriteLine($"▶ Atacas a {enemy.Name} por {dmgToEnemy.ToGameFormat()} daño");
                Console.WriteLine($"   Vida enemigo: {Math.Max(0, enemy.Health).ToGameFormat()}");

                if (enemy.Health <= 0)
                    break;

                double dmgToPlayer = Math.Max(1, enemy.Attack - player.TotalArmor);
                player.CurrentHealth -= dmgToPlayer;

                Console.WriteLine($"◀ {enemy.Name} te ataca por {dmgToPlayer.ToGameFormat()}");
                Console.WriteLine($"   Tu vida: {Math.Max(0, player.CurrentHealth).ToGameFormat()}");

                Console.WriteLine("\nPulsa ENTER para el siguiente turno...");
                Console.ReadLine();
                Console.Clear();
            }
        }


        public static void GiveItemToPlayer(Item item, Player player)
        {
            switch (item.Type)
            {
                case ItemType.Potion:
                    player.Health += item.Value;
                    break;
                case ItemType.Weapon:
                    player.Attack += item.Value;
                    break;
                case ItemType.Armor:
                    player.Armor += item.Value;
                    break;
            }

            player.Items.Add(item);
        }

        public static bool StartMission(Player player, double baseHealth, double baseAttack, double baseArmor)
        {
            var rooms = GetGameData<Room>("Rooms.json");

            bool survived = Enumerable.Range(1, 10)
                .All(floor =>
                {
                    RoomController.ResolveRoom(player, rooms, floor);
                    return player.CurrentHealth > 0;
                });

            if (!survived)
                return false;

            RewardPlayer(player, baseHealth, baseAttack, baseArmor);
            return true;
        }



        public static Mission GetRandomMission()
        {
            var missions = GetGameData<Mission>("Missions.json");
            Random rnd = new Random();
            return missions[rnd.Next(missions.Count)];
        }

        public static void StartNewMission(Player player)
        {
            double baseHealth = player.Health;
            double baseAttack = player.Attack;
            double baseArmor = player.Armor;

            player.ResetToBase();

            var mission = GetRandomMission();

            Console.Clear();
            Console.WriteLine($"MISIÓN: {mission.Title}\n");
            Console.WriteLine(mission.Description);
            Console.WriteLine("\nPulsa ENTER para comenzar...");
            Console.ReadLine();

            StartMission(player, baseHealth, baseAttack, baseArmor);
        }

        public static void RewardPlayer(Player player, double baseHealth, double baseAttack, double baseArmor)
        {
            int bonusHealth = (int)Math.Ceiling(baseHealth * 0.10);
            int bonusAttack = (int)Math.Ceiling(baseAttack * 0.10);
            int bonusArmor = (int)Math.Ceiling(baseArmor * 0.10);

            player.Health += bonusHealth;
            player.Attack += bonusAttack;
            player.Armor += bonusArmor;

            player.Health = Math.Round(player.Health, 1);
            player.Attack = Math.Round(player.Attack, 1);
            player.Armor = Math.Round(player.Armor, 1);

            player.ResetToBase();

            ShowVictory(bonusHealth, bonusAttack, bonusArmor);
            SaveCourier(player);
        }


        public static void SaveGameData<T>(string jsonFileName, List<T> data)
        {
            string jsonPath = Path.GetFullPath(
                Path.Combine("..", "..", "..", "Data", jsonFileName));

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            File.WriteAllText(jsonPath, JsonSerializer.Serialize(data, options));
        }

        public static void SaveCourier(Player player)
        {
            var couriers = GetGameData<Player>("Couriers.json");

            int index = couriers.FindIndex(c => c.Name == player.Name);

            if (index >= 0)
                couriers[index] = player;
            else
                couriers.Add(player);

            SaveGameData("Couriers.json", couriers);
        }
    }
}
