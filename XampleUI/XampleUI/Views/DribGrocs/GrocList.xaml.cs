using System.Threading.Tasks;
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

		private async void SwipeToShowCart(object sender, SwipedEventArgs e)
		{
			uint duration = 700;

			await Task.WhenAll(
				CartPreviewContainer.FadeTo(0, 500),
				RootContainer.TranslateTo(0, -540, duration, Easing.CubicIn),
				CartContainer.TranslateTo(0, -110, duration, Easing.CubicIn)
			);
		}

		private async void SwipeToShowList(object sender, SwipedEventArgs e)
		{
			uint duration = 700;

			await Task.WhenAll(
				CartPreviewContainer.FadeTo(1, 500),
				RootContainer.TranslateTo(0, 0, duration, Easing.CubicOut),
				CartContainer.TranslateTo(0, 0, duration, Easing.CubicOut)
			);
		}
	}
}