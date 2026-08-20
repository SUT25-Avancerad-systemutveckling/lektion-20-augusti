using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<IActionResult> Index(double lat = 57.1, double lon = 12.25)
        {
            var forecast = await _weatherService.GetCurrentWeather(lat, lon);

            return View(forecast);
        }
    }
}
