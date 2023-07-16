using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloLinqSDA
{
    public class DataContext
    {
        private const string filePath = "data.json";
        public static async Task<List<CarData>> MockarooCarData()
        {
            var fileContent = await File.ReadAllTextAsync(filePath);
            var cars = JsonSerializer.Deserialize<List<CarData>>(fileContent);

            return cars;
        }
    }
}
