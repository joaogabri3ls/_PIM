using _PIM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IActionResult> Index()
    {
        var city = "Araraquara"; 
        var weatherData = await _weatherService.GetWeatherAsync(city);

        return View(weatherData); 
    }
}
