using Courier.Controllers;
using Courier.Model;
using Courier.View;
using System.Linq;

namespace Courier
{
    class Program
    {


        // Al crear un nuevo personaje guardarlo en json de couriers
        // Añadir planta de la sala y boss Room
        static void Main(string[] args)
        {
            MenuView.IntroMenu();
            Console.ReadLine();

            while (true)
            {
                MenuView.ShowMenu();

                if (!int.TryParse(Console.ReadLine(), out int opc))
                    continue;

                switch (opc)
                {
                    case 1:
                        {
                            var couriers = GameController.GetGameData<Player>("Couriers.json");
                            var player = MenuView.GetCourier(couriers);

                            if (MenuView.NewMision())
                                GameController.StartNewMission(player);

                            break;
                        }

                    case 2:
                        {
                            int classChoice = MenuView.ShowClasses();

                            var classes = GameController.GetGameData<CourierClass>("Classes.json");
                            var chosenClass = classes[classChoice - 1];

                            Player player = new Player
                            {
                                Name = "Courier",
                                Class = (CourierClassEnum)(classChoice - 1),
                                Health = chosenClass.Health,
                                Attack = chosenClass.Attack,
                                Armor = chosenClass.Armor,
                                EvadeChance = chosenClass.EvadeChance,
                                HackSkill = chosenClass.HackSkill,
                                CritChance = 20,
                                Items = new(),
                                Icon = chosenClass.Icon,
                                HasPackage = true,
                                CurrentRoom = 0,
                                CurrentBuilding = 1
                            };

                            if (MenuView.NewMision())
                                GameController.StartNewMission(player);

                            break;
                        }

                    case 3:
                        return;
                }
            }
        }
    }
}
