using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleUI.ViewModels.Groc;

namespace XampleUI.Views.DribGrocs
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GrocDetail : ContentPage
	{
		public GrocDetail()
		{
			InitializeComponent();
			BindingContext = new GrocDetailViewModel();
		}

		private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}
	}
}