using System;
using static Courier.View.MenuView;
using static Courier.Controllers.GameController;
using Courier.Model;
namespace Courier
{
    class Program
    {
        static void Main(string[] args)
        {
            IntroMenu();
            Console.ReadLine();
            while (true)
            {
                NewMision();
                LoadGame();
                ShowMenu();
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int opc))
                {
                    Console.WriteLine("Introduce un número válido.");
                    continue;
                }

                switch (opc)
                {
                    case 1:
                    
                        ShowCouriers();
                        break;
                    case 2:
                        CreateCourier();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo...");
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            }
        }

        public static void LoadGame()
        {
            // Iniciar partida
            //var courierClasses =  GetGameData<CourierClass>("Classes.json");
           // var enemies = GetGameData<Enemy>("Enemies.json");
           // var items = GetGameData<Item>("Items.json");
           // var couriers = GetGameData<Player>("Couriers.json");
            //var rooms = GetGameData<Room>("Rooms.json");
        }

        public static void ShowCouriers()
        {
            var couriers = GetGameData<Player>("Couriers.json");
            GetCourier(couriers);
        }

        public static void CreateCourier()
        {
            ShowClasses();
        }
    }

}
