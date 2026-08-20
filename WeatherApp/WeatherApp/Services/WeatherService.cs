using System.Globalization;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService: IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecast> GetCurrentWeather(double lat, double lon)
        {
            var url = $"forecast?latitude={lat.ToString(CultureInfo.InvariantCulture)}" +
          $"&longitude={lon.ToString(CultureInfo.InvariantCulture)}" +
          "&current=temperature_2m";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<WeatherApiResponse>(json);

                return data.Current;
            }
            catch (Exception ex) {
                return null;
            }
        }

    }

    internal class WeatherApiResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("current")]
        public WeatherForecast? Current { get; set; }
    }
}
