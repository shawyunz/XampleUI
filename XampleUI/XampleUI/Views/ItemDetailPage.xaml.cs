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
	}
}