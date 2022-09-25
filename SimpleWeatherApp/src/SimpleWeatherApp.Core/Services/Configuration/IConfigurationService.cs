using SimpleWeatherApp.Core.Models.Settings.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SimpleWeatherApp.Core.Services.Configuration
{
    public interface IConfigurationService
    {
        string WeatherApiKey { get; set; }
        double FavoritePlaceLat { get; set; }
        double FavoritePlaceLon { get; set; }
        TemperatureUnits PreferredUnits { get; set; }
    }
}
