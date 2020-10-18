using Plugin.SharedTransitions;
using System;
using Xamarin.Forms;
using XampleUI.Views.XFShell;
using XampleUI.Views.DribCakes;

namespace XampleUI
{
	public partial class AppShell : SharedTransitionShell
	{
		public AppShell()

		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
			Routing.RegisterRoute(nameof(AboutTransitionPage), typeof(AboutTransitionPage));

			Routing.RegisterRoute(nameof(DribCakes), typeof(DribCakes));
			Routing.RegisterRoute(nameof(CakeList), typeof(CakeList));
			Routing.RegisterRoute(nameof(CakeDetail), typeof(CakeDetail));
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//LoginPage");
		}
	}
}