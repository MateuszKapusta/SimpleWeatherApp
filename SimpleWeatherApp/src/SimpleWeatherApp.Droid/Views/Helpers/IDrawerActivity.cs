using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.DrawerLayout.Widget;

namespace SimpleWeatherApp.Droid.Views.Helpers
{
    public interface IDrawerActivity
    {
        DrawerLayout DrawerLayout { get; }

        ActionBar SupportActionBar { get; }

        void HideSoftKeyboard();
    }
}
