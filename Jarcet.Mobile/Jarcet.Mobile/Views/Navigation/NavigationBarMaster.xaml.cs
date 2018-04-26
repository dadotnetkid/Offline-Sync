using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationBarMaster : ContentPage
    {
        public ListView ListView;

        public NavigationBarMaster()
        {
            InitializeComponent();

            BindingContext = new NavigationBarMasterViewModel();
            ListView = MenuItemsListView;
        }

      
    }
    public class NavigationBarMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NavigationBarMenuItem> MenuItems { get; set; }

        public NavigationBarMasterViewModel()
        {
            MenuItems = new ObservableCollection<NavigationBarMenuItem>(new[]
            {
                new NavigationBarMenuItem { Icon="search_icon.png",Id = 0, Title = "Qoutes",TargetType=typeof(Views.Qoute.Qoutes) },
                new NavigationBarMenuItem { Icon="clients.png",Id = 1, Title = "Clients",TargetType=typeof(Views.Client.Clients) },
                new NavigationBarMenuItem { Id = 2, Title = "Products" ,TargetType=typeof(Views.Product.Products) },
                new NavigationBarMenuItem { Id = 3, Title = "Page 4" },
                new NavigationBarMenuItem { Id = 4, Title = "Logout" },
            });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}