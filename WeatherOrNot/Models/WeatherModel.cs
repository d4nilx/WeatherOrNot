using System.Text.Json.Serialization;

namespace WeatherOrNot.Models;

public class WeatherResponse
{
    [JsonPropertyName("location")]
    public Location Location { get; set; }
    
    [JsonPropertyName("current")]
    public CurrentWeather Current { get; set; }
}

public class Location
{
    [JsonPropertyName("name")] 
    public string Name { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
    
    [JsonPropertyName("region")]
    public string Region { get; set; }
    
    [JsonPropertyName("localtime")]
    public string LocalTime { get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("temp_c")]
    public double Temp_C { get; set; }
    
    [JsonPropertyName("temp_f")]
    public double Temp_F { get; set; }
    
    [JsonPropertyName("feelslike_c")]
    public double FeelsLike_C { get; set; }
    
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
    
    [JsonPropertyName("wind_kph")]
    public double Wind_Kph { get; set; }
    
    [JsonPropertyName("wind_dir")]
    public string Wind_dir { get; set; }
    
    [JsonPropertyName("condition")]
    public Condition Condition { get; set; }
}

public class Condition
{
    [JsonPropertyName("text")]
    public string Text { get; set; } 

    [JsonPropertyName("icon")]
    public string Icon { get; set; } 
}