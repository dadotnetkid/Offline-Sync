using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Mobile.Models;
using Jarcet.Mobile.Models.Client;
using Jarcet.Mobile.Services;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewClient : ContentPage
    {
        private AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
        public NewClient()
        {
            InitializeComponent();
            model = new Models.Client.ClientViewModel() { Clients = new Models.Clients() };
            BindingContext = model;
        }

        public ClientViewModel model { get; set; }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Run(async () =>
           {
               await unitOfWork.CategoriesRepo.PullAsync();
               var res = await unitOfWork.CategoriesRepo.GetAsync(m => m.Type == (int)TableType.Clients);
               model.CategoriesList = new System.Collections.ObjectModel.ObservableCollection<Models.Categories>(res);

           });
        }

        private async void MenuItemSaveClient_Click(object sender, EventArgs e)
        {
            model.Clients.Id = Guid.NewGuid().ToString();
            await unitOfWork.ClientsRepo.AddAsync(JObject.FromObject(model.Clients));
            await unitOfWork.ClientsRepo.PushAsync();
            await Navigation.PopAsync();
        }

        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var categories = picker.SelectedItem as Categories;
            model.Clients.CategoryId = categories?.Id;
        }
    }
}