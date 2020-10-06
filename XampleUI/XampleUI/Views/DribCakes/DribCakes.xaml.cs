using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleUI.Views.DribCakes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DribCakes : ContentPage
	{
		public DribCakes()
		{
			InitializeComponent();
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CakeList());
		}
	}
}