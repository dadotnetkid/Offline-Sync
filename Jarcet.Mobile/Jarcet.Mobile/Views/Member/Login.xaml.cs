using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Mobile.Models;
using Jarcet.Mobile.Models.User;
using Jarcet.Mobile.Services;
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
            users = new UserViewModel() { Users = new Users() };
            BindingContext = users;

        }

        private async void BtnLogin(object sender, EventArgs e)
        {
            var res = await MobileServiceUsers.LoginUserAsync(new Users() { UserName = users.Users.UserName, Password = users.Users.Password });
            if (res)
            {
                Application.Current.MainPage = new Navigation.NavigationBar();
            }
            else
            {
                users.Users.UserName = "";
                users.Users.Password = "";
                await DisplayAlert("Invalid Credentials", "Check username and password", "Ok");
               
            }

        }
    }
}