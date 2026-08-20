using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class WeatherForecast
    {
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;
    }
}
