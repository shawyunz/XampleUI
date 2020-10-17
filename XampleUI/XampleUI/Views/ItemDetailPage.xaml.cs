using System.ComponentModel;
using Xamarin.Forms;
using XampleUI.ViewModels;

namespace XampleUI.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}

		private void Button_Clicked(object sender, System.EventArgs e)
		{
			//NavigationPage.Push(new Page2());
		}
	}
}