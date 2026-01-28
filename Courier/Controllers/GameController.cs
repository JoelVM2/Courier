using Courier.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Courier.Controllers
{
    internal class GameController
    {
        // Cargar objetos en listas estáticas, de cada modelo
        public static void getGameData()
        {
            string jsonPath = Path.Combine("..", "..", "..", "Data", "Classes.json");
            jsonPath = Path.GetFullPath(jsonPath);
            if (!File.Exists(jsonPath))
            {
                Console.WriteLine("No se encontró el archivo" + jsonPath);
            }
            else
            {
                Console.WriteLine("HOla1");
                string jsonString = File.ReadAllText(jsonPath);
                Console.WriteLine("HOla2");
                List<CourierClass> courierClasses = JsonSerializer.Deserialize<List<CourierClass>>(jsonString);
                Console.WriteLine(jsonString);

               
                    Console.WriteLine($"{courierClasses[0].Name}");
                
            }
            
        }

        public static List<T> GetGameData<T>(string jsonFileName)
        {
            string jsonPath = Path.Combine("..", "..", "..", "Data", jsonFileName);
            jsonPath = Path.GetFullPath(jsonPath);

            if (!File.Exists(jsonPath))
                throw new FileNotFoundException($"No se encontró el archivo: {jsonPath}");

            string jsonString = File.ReadAllText(jsonPath);

            List<T> objects = JsonSerializer.Deserialize<List<T>>(jsonString);

            return objects;
        }
    }
}
