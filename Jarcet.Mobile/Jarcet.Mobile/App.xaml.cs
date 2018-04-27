using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarcet.Mobile.Services;
using Jarcet.Mobile.Services.OfflineSyncService;
using Jarcet.Mobile.Views.Member;
using Jarcet.Mobile.Views.Navigation;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Jarcet.Mobile
{
    public partial class App : Application
    {
        private OfflineSyncService syncService;
        public App()
        {
            InitializeComponent();
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            if (MobileServiceUsers.GetCredentials())
            {
                MainPage = new NavigationBar();
                return;
            }
            MainPage = new Login();

        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            syncService =  new OfflineSyncService(new AzureOfflineSyncService());
            if (e.IsConnected && MobileServiceUsers.GetCredentials())
            {

                await syncService.Push();
                await syncService.Pull();
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IPopupServices>().ShowSnackBar("Succesfully sync to the cloud", 1000);
                }
            }
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
