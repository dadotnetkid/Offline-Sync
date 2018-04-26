using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarcet.Mobile.Services;
using Jarcet.Mobile.Views.Member;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationBar : MasterDetailPage
    {
        public NavigationBar()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NavigationBarMenuItem;
            if (item == null)
                return;
            if (item.Title == "Logout")
            {
                MobileServiceUsers.Logout();
                Application.Current.MainPage = new Login();
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}