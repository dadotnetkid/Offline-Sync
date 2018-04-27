using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Jarcet.Mobile.Models;
using Jarcet.Mobile.Models.User;
using Jarcet.Mobile.Services;
using Jarcet.Mobile.Services.OfflineSyncService;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Member
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
        private UserViewModel users;

        public Login()
        {
            InitializeComponent();
            users = new UserViewModel() { };
            BindingContext = users;
            if (Device.RuntimePlatform == Device.Android)
            {

            }
        }

        private async void BtnLogin(object sender, EventArgs e)
        {
            using (IProgressDialog progressDialog =
                UserDialogs.Instance.Loading("Progress", maskType: MaskType.Gradient))
            {
                var res = await MobileServiceUsers.LoginUserAsync(new Users() { UserName = users.UserName, Password = users.Password });
                if (res)
                {
                    var syncService = new OfflineSyncService(new AzureOfflineSyncService());
                    await syncService.Pull();
                    Application.Current.MainPage = new Navigation.NavigationBar();
                }
                else
                {
                    users.UserName = "";
                    users.Password = "";
                    await DisplayAlert("Invalid Credentials", "Check username and password", "Ok");

                }
            }


        }

        private void Username_Completed(object sender, EventArgs e)
        {

        }
    }
}