using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Mobile.Models.Product;
using Jarcet.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        private AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
        public Products()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await unitOfWork.ProductsRepo.PullAsync(null);
            var res = await unitOfWork.ProductsRepo.GetAsync();
            BindingContext = new ProductsViewModel()
            {
                ProductList = new System.Collections.ObjectModel.ObservableCollection<Models.Products>(res)
            };
        }
    }
}