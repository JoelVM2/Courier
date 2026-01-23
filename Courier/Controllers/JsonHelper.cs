using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Courier.Controllers
{
    internal class JsonHelper
    {

        public static async Task<T> readJsonFile<T>(string filePath)
        {
            string json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
