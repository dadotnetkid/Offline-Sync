using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Jarcet.Mobile.Models.Product
{
    public class ProductsViewModel : NotifyPropertyService
    {
        private ObservableCollection<Products> productList;

        public ObservableCollection<Products> ProductList
        {
            get { return productList; }
            set
            {
                productList = value;
                OnPropertyChanged();
            }
        }
        private Products products;

        public Products Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }


    }
}
