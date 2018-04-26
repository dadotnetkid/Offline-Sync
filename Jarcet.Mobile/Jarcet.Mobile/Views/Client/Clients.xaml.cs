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
        public Clients()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await unitOfWork.ClientsRepo.PullAsync(null);
            var res = await unitOfWork.ClientsRepo.GetAsync();
            BindingContext = new ClientViewModel() { ClientList = new ObservableCollection<Models.Clients>(res) };
        }

        private async void MenuItemNewClient_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewClient());
        }
    }
}