using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleUI.Models;

namespace XampleUI.Views.DribComp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompAir : ContentPage
	{

		public ObservableCollection<ItemAir> ItemsCompa { get;  private set; }

		public CompAir()
		{
			InitializeComponent();

			ItemsCompa = new ObservableCollection<ItemAir>()
			{
				new ItemAir { Id = Guid.NewGuid().ToString(), Text = "Southwest", SeatPitch="", Image="itemair1.png" },
				new ItemAir { Id = Guid.NewGuid().ToString(), Text = "VgAmerica", Image="itemair2.png", SeatPitch="" },
				new ItemAir { Id = Guid.NewGuid().ToString(), Text = "JetBlue",  Image="itemair3.png", SeatPitch="" },
				new ItemAir { Id = Guid.NewGuid().ToString(), Text = "HAWAIIAN", Image="itemair4.png", SeatPitch="" },
				new ItemAir { Id = Guid.NewGuid().ToString(), Text = "DELTA",  Image="itemair5.png", SeatPitch="" }
			};

			BindingContext = this;
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
		}
}