using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarcet.Mobile.Services;
using Jarcet.Mobile.Views.Member;
using Jarcet.Mobile.Views.Navigation;
using Xamarin.Forms;

namespace Jarcet.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (MobileServiceUsers.GetCredentials())
            {
                MainPage = new NavigationBar();
                return;
            }
            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
