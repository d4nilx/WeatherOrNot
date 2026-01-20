using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherOrNot.View_Models;

namespace WeatherOrNot;

public partial class CityListPage : ContentPage
{
    public CityListPage()
    {
        InitializeComponent();
        BindingContext = new CityListViewModel();
    }
}