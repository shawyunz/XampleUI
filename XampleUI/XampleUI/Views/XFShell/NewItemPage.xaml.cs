using Xamarin.Forms;

using XampleUI.Models;
using XampleUI.ViewModels.XFShell;

namespace XampleUI.Views.XFShell
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

		public NewItemPage()
		{
			InitializeComponent();
			BindingContext = new NewItemViewModel();
		}
	}
}