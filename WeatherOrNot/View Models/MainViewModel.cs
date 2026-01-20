using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherOrNot.Services;
using WeatherOrNot.Models;

namespace WeatherOrNot.View_Models;

[QueryProperty(nameof(SelectedCity), "CityName")]
public partial class MainViewModel: ObservableObject
{
    API_Services _apiServices = new API_Services();
    
    [ObservableProperty] string cityQuery;
    
    [ObservableProperty] string selectedCity;
    
    [ObservableProperty] WeatherResponse? weatherData;
    [ObservableProperty] string iconUrl;
    [ObservableProperty] bool isBusy;
    [ObservableProperty] string errorMessage;
    
    public bool IsVisible => WeatherData != null;

    public MainViewModel()
    {
        CityQuery = "";
    }
    
    async partial void OnSelectedCityChanged(string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            CityQuery = value; 
            await SearchWeather(); 
        }
    }
    
    [RelayCommand]
    async Task SearchWeather()
    {
        if (IsBusy || string.IsNullOrWhiteSpace(CityQuery)) return;

        try
        {
            IsBusy = true;
            ErrorMessage = "";
            

            var response = await _apiServices.GetWeatherAsync(CityQuery);

            if (response != null)
            {
                WeatherData = response;
                IconUrl = "https:" + response.Current.Condition.Icon;
            }
            else
            {
                ErrorMessage = "Can't find city 🤷‍♂️";
                WeatherData = null;
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = "Internet problems :(";
        }
        finally
        {
            IsBusy = false;
            OnPropertyChanged(nameof(IsVisible));
        }
    }
    
    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync(".."); 
    }
    
    [RelayCommand]
    async Task SaveCity()
    {
        if (WeatherData == null) return;
        
        var existingCity = CityListViewModel.GlobalCities.FirstOrDefault(c => c.Location.Name == WeatherData.Location.Name);
        
        if (existingCity == null)
        {
            CityListViewModel.GlobalCities.Add(WeatherData);
            await Shell.Current.DisplayAlert("Greate!", $"{WeatherData.Location.Name} added to the list.", "ОК");
        }
        else
        {
            await Shell.Current.DisplayAlert("Oops!", "City is in the list already.", "ОК");
        }
    }
}