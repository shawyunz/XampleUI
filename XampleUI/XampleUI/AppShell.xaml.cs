using Plugin.SharedTransitions;
using Xamarin.Forms;
using XampleUI.Views.DribBank;
using XampleUI.Views.DribCakes;
using XampleUI.Views.DribComp;
using XampleUI.Views.DribGrocs;
using XampleUI.Views.XFShell;

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

			Routing.RegisterRoute(nameof(GrocList), typeof(GrocList));
			Routing.RegisterRoute(nameof(GrocDetail), typeof(GrocDetail));

			Routing.RegisterRoute(nameof(CompAir), typeof(CompAir));

			Routing.RegisterRoute(nameof(CardList), typeof(CardList));
		}
	}
}