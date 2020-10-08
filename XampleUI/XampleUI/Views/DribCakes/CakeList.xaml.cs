using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleUI.Views.DribCakes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CakeList : ContentPage
	{
		public CakeList()
		{
			InitializeComponent();
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("CakeDetail");
		}
	}
}