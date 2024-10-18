using System;
using System.Net.Http;
using System.Threading.Tasks;
using _PIM.Models;
using Newtonsoft.Json;

namespace _PIM.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "045b298b08443706625d77e1629b431a";
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            var url = $"{_baseUrl}?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<WeatherData>(response);
            }

            return null;
        }
    }
}
