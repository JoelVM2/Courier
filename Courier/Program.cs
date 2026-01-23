using System;
using static Courier.View.MenuView;
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
                ShowMenu();
                Console.Write("Opción: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int opc))
                {
                    Console.WriteLine("Introduce un número válido.");
                    continue;
                }

                switch (opc)
                {
                    case 1:

                        break;
                    case 2:
                        
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
    }
}
