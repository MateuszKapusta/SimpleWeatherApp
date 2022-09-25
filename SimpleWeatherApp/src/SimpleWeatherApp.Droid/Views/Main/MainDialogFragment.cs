using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using SimpleWeatherApp.Core.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWeatherApp.Droid.Views.Main
{
    [MvxDialogFragmentPresentation]
    [Register(nameof(MainDialogFragment))]
    public class MainDialogFragment : BaseDialogFragment<MainDialogViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_main_dialog;

        //public override Dialog OnCreateDialog(Bundle savedInstanceState)
        //{
        //    return new AlertDialog.Builder(Activity)
        //      .Create();
        //}

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            if (Dialog is AlertDialog alertDialog)
            {
                alertDialog.SetView(view);
            }
        }
    }
}