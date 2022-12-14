using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Navigation;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using SimpleWeatherApp.Core.ViewModels.Main;
using SimpleWeatherApp.Core.ViewModels.Menu;
using SimpleWeatherApp.Droid.Views.Helpers;

namespace SimpleWeatherApp.Droid.Views.Menu
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.navigation_frame)]
    public class MenuFragment : BaseFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_navigation;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);

            NavigationView navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            navigationView.SetNavigationItemSelectedListener(this);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            switch (menuItem.ItemId)
            {
                case Resource.Id.nav_home:
                    ViewModel.ShowHomeCommand.Execute();
                    break;
                case Resource.Id.nav_weather:
                    ViewModel.ShowWeatherCommand.Execute();
                    break;
                case Resource.Id.nav_settings:
                    ViewModel.ShowSettingsCommand.Execute();
                    break;
            }

            (Activity as IDrawerActivity)?.DrawerLayout.CloseDrawers();
            return true;
        }
    }
}
