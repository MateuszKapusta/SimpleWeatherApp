using SimpleWeatherApp.Core.Models.Settings.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SimpleWeatherApp.Core.Services.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        #region Setting Constants

        private const string KeyWeatherApiKey = "weather_api_key";
        private const string KeyFavoritePlaceName = "favorite_place_Name";
        private const string KeyFavoritePlaceLat = "favorite_place_lat";
        private const string KeyFavoritePlaceLon = "favorite_place_lon";
        private const string KeyPreferredUnits = "preferred_units";

        private readonly string WeatherApiKeyDefault = "8341ee30993be9305f759305dc801801";
        private readonly string FavoritePlaceNameDefault = string.Empty;
        private readonly double FavoritePlaceLatDefault = 0.0;
        private readonly double FavoritePlaceLonDefault = 0.0;
        private readonly int PreferredUnitsDefautl = (int)TemperatureUnits.standard;

        #endregion


        public string WeatherApiKey
        {
            get => Preferences.Get(KeyWeatherApiKey, WeatherApiKeyDefault);
            set => Preferences.Set(KeyWeatherApiKey, value);
        }

        public string FavoritePlaceName
        {
            get => Preferences.Get(KeyFavoritePlaceName, FavoritePlaceNameDefault);
            set => Preferences.Set(KeyFavoritePlaceName, value);
        }

        public double FavoritePlaceLat
        {
            get => Preferences.Get(KeyFavoritePlaceLat, FavoritePlaceLatDefault);
            set => Preferences.Set(KeyFavoritePlaceLat, value);
        }

        public double FavoritePlaceLon
        {
            get => Preferences.Get(KeyFavoritePlaceLon, FavoritePlaceLonDefault);
            set => Preferences.Set(KeyFavoritePlaceLon, value);
        }

        public TemperatureUnits PreferredUnits
        {
            get => (TemperatureUnits)Preferences.Get(KeyPreferredUnits, PreferredUnitsDefautl);
            set => Preferences.Set(KeyPreferredUnits, (int)value);
        }

    }
}
