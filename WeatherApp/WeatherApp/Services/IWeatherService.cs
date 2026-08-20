using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetCurrentWeather(double lat, double lon);
    }
}
