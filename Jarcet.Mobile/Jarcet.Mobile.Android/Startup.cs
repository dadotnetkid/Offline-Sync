using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Jarcet.Mobile.Droid
{
    public partial class MainActivity
    {
        public void ConfigureApplication()
        {
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
            UserDialogs.Init(() => (Activity)Forms.Context);
        }
    }
}