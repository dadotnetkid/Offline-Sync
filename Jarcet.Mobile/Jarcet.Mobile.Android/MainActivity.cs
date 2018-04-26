using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Jarcet.Mobile.Droid
{
    [Activity(Label = "MedTek", Icon = "@drawable/medtek", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            var view = ((Activity)Forms.Context).FindViewById(Android.Resource.Id.Content);
            if (!CrossConnectivity.Current.IsConnected)
            {

                Snackbar.Make(view, "You dont have internet connection", 600).Show();
            }

            CrossConnectivity.Current.ConnectivityTypeChanged += async (s, e) =>
            {
                if (!e.IsConnected)
                    Snackbar.Make(view, "You dont have internet connection", 600).Show();

            };
        }
    }
}

