using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleUI.Views.DribCakes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CakeDetail : ContentPage
	{
		public CakeDetail()
		{
			InitializeComponent();
		}

		private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}
	}
}