using System.Text.Json.Serialization;

namespace Weather.Data.Models
{
    public class ZipResponse
    {
        [JsonPropertyName("zip")]
        public string? Zip { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        
        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }
}