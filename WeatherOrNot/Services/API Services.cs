using System.Text.Json;
using WeatherOrNot.Models;

namespace WeatherOrNot.Services;

public class API_Services
{
    HttpClient _client;
    
    public API_Services()
    {
        _client = new HttpClient();
    }

    public async Task<WeatherResponse?> GetWeatherAsync(string city)
    {
        string apiKey = "Your API Key";
        
        string url = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

        try
        {
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<WeatherResponse>(content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
        return null;
    }
}