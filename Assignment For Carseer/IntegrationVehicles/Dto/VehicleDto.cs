using System.Text.Json.Serialization;

namespace Assignment_For_Carseer.IntegrationVehicles.Dto
{
    public class VehicleDto
    {
        [JsonPropertyName("Make_ID")]
        public long MakeId { get; set; }

        [JsonPropertyName("Make_Name")]
        public string MakeName { get; set; }
        
        [JsonPropertyName("Model_ID")]
        public long ModelId { get; set; }

        [JsonPropertyName("Model_Name")]
        public string ModelName { get; set; }
    }
}
