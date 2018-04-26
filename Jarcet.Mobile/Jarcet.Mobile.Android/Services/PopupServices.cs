using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Jarcet.Mobile.Services;
using Xamarin.Forms;
using Application = Android.App.Application;

namespace Jarcet.Mobile.Droid.Services
{
    public class PopupServices : IPopupServices
    {
        public void ShowToast(string message, int duration)
        {
            Toast.MakeText(Application.Context, message, (ToastLength)duration).Show();
        }

        public void ShowSnackBar(string message, int duration)
        {
            var view = ((Activity)Forms.Context).FindViewById(Android.Resource.Id.Content);
            Snackbar.Make(view, message, duration).Show();

        }
    }
}