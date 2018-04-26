using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Mobile.Models.Client;
using Jarcet.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clients : ContentPage
    {
        private AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
        private ClientViewModel model = new ClientViewModel();

        public Clients()
        {
            InitializeComponent();
            BindingContext = model;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            model.IsRefreshing = true;
            await unitOfWork.ClientsRepo.PullAsync(null);
            var res = await unitOfWork.ClientsRepo.GetAsync();
            model.ClientList = new ObservableCollection<Models.Clients>(res);
            model.IsRefreshing = false;
        }

        private async void MenuItemNewClient_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewClient());
        }
    }
}