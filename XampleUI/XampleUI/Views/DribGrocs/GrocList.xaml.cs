using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleUI.ViewModels.Groc;

namespace XampleUI.Views.DribGrocs
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GrocList : ContentPage
	{
		private GrocsViewModel _viewModel;

		public GrocList()
		{
			InitializeComponent();

			BindingContext = _viewModel = new GrocsViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();
		}

		private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
		{
			await DisplayAlert("Detected", "Up", "OK");
		}
	}
}