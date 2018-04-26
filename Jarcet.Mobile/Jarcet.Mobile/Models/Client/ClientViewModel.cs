using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Jarcet.Mobile.Models.Client
{
    public partial class ClientViewModel : NotifyPropertyService
    {
        private ObservableCollection<Clients> clientList;

        public ObservableCollection<Clients> ClientList
        {
            get { return clientList; }
            set
            {
                clientList = value;
                this.OnPropertyChanged();
            }
        }
        private Clients clients;

        public Clients Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged();
            }
        }

    }
}
