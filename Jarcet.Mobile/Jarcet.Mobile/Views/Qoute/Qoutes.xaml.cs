using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Mobile.Models.Qoute;
using Jarcet.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Qoute
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Qoutes : ContentPage
    {
        private AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
        public Qoutes()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await unitOfWork.QoutesRepo.PullAsync(null);
            var res = (await unitOfWork.QoutesRepo.GetAsync()).ToList();
            BindingContext = new QoutesViewModel()
            {
                QouteList = new System.Collections.ObjectModel.ObservableCollection<Models.Qoutes>(res)
            };
        }
        

        private async void OnDetails(object sender, EventArgs e)
        {
            var commandParam = ((MenuItem)sender)?.CommandParameter as Models.Qoutes;
            await unitOfWork.ProductsRepo.PurgeAsync(m => m.Id == commandParam.Id);
            await unitOfWork.QoutesRepo.DeleteAllAsync();
            await DisplayAlert("Details", commandParam?.Subject, "Ok");
        }

        private async void AddQoute(object sender, EventArgs e)
        {
            //   await Navigation.PushModalAsync(new NewQoute());
            // Application.Current.MainPage = new NavigationPage(new NewQoute());
            await Navigation.PushAsync(new NewQoute());
        }
    }
}