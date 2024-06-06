using System.Text.Json.Serialization;

namespace Weather.Data.Models
{
    public class CityResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
        
        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}