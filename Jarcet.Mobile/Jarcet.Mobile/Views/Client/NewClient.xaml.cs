using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarcet.Mobile.Views.Client
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewClient : ContentPage
	{
		public NewClient ()
		{
			InitializeComponent ();
		}

	    private void MenuItemAddClient_Click(object sender, EventArgs e)
	    {
	        
	    }

	    private async void MenuItemSaveClient_Click(object sender, EventArgs e)
	    {
	        await Navigation.PopAsync();
	    }
	}
}