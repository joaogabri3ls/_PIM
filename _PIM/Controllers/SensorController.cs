using Microsoft.AspNetCore.Mvc;
using _PIM.Services;
using _PIM.Models;
using System.Threading.Tasks;

namespace _PIM.Controllers
{
    public class SensorController : Controller
    {
        private readonly WeatherService _weatherService;

        public SensorController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string city = "São Paulo")
        {
            // Chama o serviço para obter dados meteorológicos
            WeatherData weatherData = await _weatherService.GetWeatherAsync(city);

            if (weatherData == null)
            {
                // Se não obtiver dados, exibe erro na view
                ViewData["Error"] = "Não foi possível obter os dados meteorológicos. Tente novamente.";
                return View("~/Views/Sensores/Sensor.cshtml");
            }

            // Se os dados forem obtidos com sucesso, passa para a view
            return View("~/Views/Sensores/Sensor.cshtml", weatherData);
        }
    }
}
