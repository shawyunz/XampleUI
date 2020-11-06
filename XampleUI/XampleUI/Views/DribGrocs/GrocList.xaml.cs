using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleUI.Models;
using XampleUI.ViewModels.Groc;

namespace XampleUI.Views.DribGrocs
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GrocList : ContentPage
	{
		private int _index;
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

			var list = _viewModel.Grocs;
			if (list is null)
			{
				return;
			}

			var box = new BoxView { CornerRadius = 10, HeightRequest = 56 };
			RightLane.Children.Add(box);

			foreach (var item in list)
			{
				AddItemLayout(item, _index);
				_index++;
			}
		}

		private void AddItemLayout(Item item, int index)
		{
			int _baseIndex = index / 2;
			var _flagRight = Convert.ToBoolean(index % 2);

			var lane = _flagRight ? RightLane : LeftLane;

			var frame = new Frame { HeightRequest = 272, Margin = 8, Padding = 0, CornerRadius = 10 };
			var stack = new StackLayout { Padding = 22, BackgroundColor = Color.White };

			var image = new Image { Source = item.Image, HeightRequest = 88, HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 16) };
			var labelPrice = new Label { Margin = new Thickness(0, 10), FontAttributes = FontAttributes.Bold, FontSize = 22, Text = "$" + item.Price, TextColor = Color.FromHex("#333333") };
			var labelText  = new Label { FontAttributes = FontAttributes.Bold, FontSize = 14, Text = item.Text, TextColor = Color.FromHex("#333333") };
			var labelSize  = new Label { LineBreakMode = LineBreakMode.NoWrap, FontSize = 13, Text = item.Size, TextColor = Color.FromHex("#CCCCCC") };

			stack.Children.Add(image);
			stack.Children.Add(labelPrice);
			stack.Children.Add(labelText);
			stack.Children.Add(labelSize);
			frame.Content = stack;
			lane.Children.Add(frame);

			var tap = new TapGestureRecognizer();
			tap.Tapped += async (object sender, EventArgs e) =>
			{
				await Shell.Current.GoToAsync($"{nameof(GrocDetail)}?{nameof(GrocDetailViewModel.ItemId)}={item.Id}");
			};
			stack.GestureRecognizers.Add(tap);
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