using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;
using Prism;
using Prism.Ioc;

namespace RideCompare.Droid
{
    [Activity(Label = "RideCompare", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Initialize Xamarin Forms Google Maps
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState); 

            // Enables Xamarin Essentials
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Enables Acr UserDialogs
            UserDialogs.Init(this);

            // Wire up Prism for Android
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}