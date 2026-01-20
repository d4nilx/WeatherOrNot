using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherOrNot.Models;

namespace WeatherOrNot.View_Models;

public partial class CityListViewModel : ObservableObject
{
    [ObservableProperty]
    string searchText;
    
    public static ObservableCollection<WeatherResponse> GlobalCities { get; } = new();
    
    public ObservableCollection<WeatherResponse> SavedCities => GlobalCities;
    
    [RelayCommand]
    async Task PerformSearch()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) return;
        
        var navigationParameter = new Dictionary<string, object>
        {
            { "CityName", SearchText }
        };
        
        SearchText = string.Empty;
        
        await Shell.Current.GoToAsync(nameof(WeatherDetailPage), navigationParameter);
    }
    
    [RelayCommand]
    void DeleteCity(WeatherResponse city)
    {
        if (GlobalCities.Contains(city))
        {
            GlobalCities.Remove(city);
        }
    }
    
    [RelayCommand]
    async Task OpenCity(WeatherResponse city)
    {
        if (city == null) return;

        var navigationParameter = new Dictionary<string, object>
        {
            { "CityName", city.Location.Name }
        };
        
        await Shell.Current.GoToAsync(nameof(WeatherDetailPage), navigationParameter);
    }
}