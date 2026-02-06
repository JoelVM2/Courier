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
