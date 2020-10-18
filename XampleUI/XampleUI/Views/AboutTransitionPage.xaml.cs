using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleUI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutTransitionPage : ContentPage
	{
		public AboutTransitionPage()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, System.EventArgs e)
		{
			//Shell.Current.GoToAsync("..");
			Navigation.PopAsync();
		}
	}
}