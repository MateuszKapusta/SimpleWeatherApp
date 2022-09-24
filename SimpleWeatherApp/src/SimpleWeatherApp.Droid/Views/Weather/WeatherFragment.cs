using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using SimpleWeatherApp.Core.ViewModels.Main;
using SimpleWeatherApp.Core.ViewModels.Settings;
using SimpleWeatherApp.Core.ViewModels.Weather;
using SimpleWeatherApp.Droid.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWeatherApp.Droid.Views.Weather
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame,true)]
    public class WeatherFragment : BaseFragment<WeatherViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_weather;
    }
}
