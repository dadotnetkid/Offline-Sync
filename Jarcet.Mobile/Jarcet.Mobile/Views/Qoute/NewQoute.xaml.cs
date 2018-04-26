using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Mobile.Models;
using Jarcet.Mobile.Models.Qoute;
using Jarcet.Mobile.Services;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Qoute
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewQoute : ContentPage
    {
        private AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
        private QoutesViewModel model;

        public NewQoute()
        {
            InitializeComponent();
            model = new QoutesViewModel()
            {
                Qoutes = new Models.Qoutes() { DateRequested = DateTime.Now, Id = Guid.NewGuid().ToString() },

            };
            BindingContext = model;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await unitOfWork.ClientsRepo.PullAsync();
            var res = await unitOfWork.ClientsRepo.GetAsync();
            if (model.ClientsList == null)
            {
                model.ClientsList = new System.Collections.ObjectModel.ObservableCollection<Clients>(res);
            }
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            var picker = sender as Picker;
            var model = BindingContext as QoutesViewModel;
            var client = picker.SelectedItem as Clients;
            model.Qoutes.Clients = client;
            model.Qoutes.ClientId = client?.Id;
        }

        private async void btnNewQouteDetail(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new NewQouteDetails(model));
        }

        private async void btnSubmitQoute(object sender, EventArgs e)
        {
            model.Qoutes.QouteDetails = model.QouteDetailList;
            await unitOfWork.QoutesRepo.AddAsync(new JObject()
            {
                ["ClientId"] = model.Qoutes.ClientId,
                ["Subject"] = model.Qoutes.Subject,
                ["DateRequested"] = model.Qoutes.DateRequested,
                ["QouteDetails"] = JToken.FromObject(model.QouteDetailList),
            });
            await unitOfWork.QoutesRepo.PushAsync();
            await DisplayAlert("Jarcet Mobile Application", " Created New Qoutes", "Ok");
            await Navigation.PopAsync();
        }
    }
}