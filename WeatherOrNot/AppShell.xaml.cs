namespace WeatherOrNot;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(WeatherDetailPage), typeof(WeatherDetailPage));
    }
}