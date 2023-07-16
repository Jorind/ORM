using System.Text.Json.Serialization;

namespace HelloLinqSDA
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class CarData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("car_make")]
        public string CarMake { get; set; }

        [JsonPropertyName("car_models")]
        public string CarModel { get; set; }

        [JsonPropertyName("car_year")]
        public int CarYear { get; set; }

        [JsonPropertyName("number_of_doors")]
        public int NumberOfDoors { get; set; }

        [JsonPropertyName("hp")]
        public int Hp { get; set; }
    }
}
