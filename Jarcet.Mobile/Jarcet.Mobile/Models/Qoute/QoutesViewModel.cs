using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Jarcet.Mobile.Models.Qoute
{
    public class QoutesViewModel : NotifyPropertyService
    {
        public QoutesViewModel()
        {

        }
        private ObservableCollection<Qoutes> _qouteList;
        public ObservableCollection<Qoutes> QouteList
        {
            get => _qouteList;
            set
            {
                _qouteList = value;
                this.OnPropertyChanged();

            }
        }
        private Qoutes qoutes;

        public Qoutes Qoutes
        {
            get { return qoutes; }
            set
            {
                if (this.qoutes == null)
                {
                    this.qoutes = new Qoutes() { DateRequested = DateTime.Now };
                }
                qoutes = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Clients> clientsList;

        public ObservableCollection<Clients> ClientsList
        {
            get { return clientsList; }
            set
            {
                clientsList = value;
                OnPropertyChanged();

            }
        }

        private ObservableCollection<QouteDetails> qouteDetailList;

        public ObservableCollection<QouteDetails> QouteDetailList
        {
            get { return qouteDetailList; }
            set
            {
                qouteDetailList = value;
                OnPropertyChanged();
            }
        }

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
        private QouteDetails qouteDetails;

        public QouteDetails QouteDetails
        {
            get { return qouteDetails; }
            set
            {
                qouteDetails = value;
                OnPropertyChanged();
            }
        }
        private int qty=1;

        public int Qty
        {
            get { return qty; }
            set
            {
                qty = value;
                OnPropertyChanged();
            }
        }



    }
}
