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
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City name must be provided", nameof(city));
            }

            try
            {
                var url = $"{_baseUrl}?q={city}&appid={_apiKey}&units=metric";
                var response = await _httpClient.GetAsync(url);

                // Verifica se a resposta foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    // Verifica se o conteúdo da resposta não é vazio
                    if (!string.IsNullOrEmpty(responseString))
                    {
                        return JsonConvert.DeserializeObject<WeatherData>(responseString);
                    }
                }
                else
                {
                    // Exceção personalizada para quando a resposta não for bem-sucedida
                    throw new Exception($"Erro ao obter dados: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Log de erro mais detalhado
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                throw new Exception("Erro de conexão com a API", ex); // Pode lançar uma exceção customizada
            }
            catch (Exception ex)
            {
                // Captura qualquer outro tipo de exceção
                Console.WriteLine($"Erro ao chamar a API: {ex.Message}");
                throw new Exception("Erro inesperado ao obter dados da API", ex);
            }

            return null; // Retorna null se não conseguir obter os dados
        }
    }
}
