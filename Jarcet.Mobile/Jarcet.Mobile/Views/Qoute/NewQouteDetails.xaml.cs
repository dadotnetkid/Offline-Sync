using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Mobile.Models;
using Jarcet.Mobile.Models.Qoute;
using Jarcet.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Qoute
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewQouteDetails : ContentPage
    {
        private AzureUnitOfWork unitOfWork = new AzureUnitOfWork();
        QoutesViewModel model;
        public NewQouteDetails(QoutesViewModel model)
        {
            InitializeComponent();
            this.model = model;
            BindingContext = model;
            model.QouteDetails = new QouteDetails();
            model.Products = new Products() { Cost = 0.0M };

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await unitOfWork.ProductsRepo.PullAsync();
            var res = await unitOfWork.ProductsRepo.GetAsync();
            model.ProductList = new System.Collections.ObjectModel.ObservableCollection<Models.Products>(res);
        }

        private void PickerOnProductSelected(object sender, EventArgs e)
        {

            var picker = sender as Picker;
            model.Products = picker?.SelectedItem as Models.Products;

        }

        private async void btnSubmitQoutedetails(object sender, EventArgs e)
        {
            List<QouteDetails> qouteDetails = new List<QouteDetails>();
            qouteDetails.Add(new QouteDetails()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = model?.Products?.Id,
                QouteId = model?.Qoutes?.Id,
                Qty = model.Qty,
                Products = model.Products

            });
            if (model.QouteDetailList != null)
            {
                model.QouteDetailList.Add(new QouteDetails()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = model?.Products?.Id,
                    QouteId = model?.Qoutes?.Id,
                    Qty = model.Qty,
                    Products = model.Products

                });
            }
            else
            {
                model.QouteDetailList =
                    new System.Collections.ObjectModel.ObservableCollection<QouteDetails>(qouteDetails);
            }
            await Navigation.PopAsync();
        }
    }
}