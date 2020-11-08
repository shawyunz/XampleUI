using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleUI.Models;

namespace XampleUI.Views.DribComp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompAir : ContentPage
	{
		public CompAir()
		{
			InitializeComponent();

			PinAirlineCmd = new Command<ItemAir>(PinAirline);

			IniteCompList();
			ItemsCompaPin = new ObservableCollection<ItemAir>();
			ItemsCompaAll = new ObservableCollection<ItemAir>()
			{
				new ItemAir { Id = "0", Text = "Southwest", SeatPitch="", Image="itemair1.png" },
				new ItemAir { Id = "1", Text = "VgAmerica", Image="itemair2.png", SeatPitch="" },
				new ItemAir { Id = "2", Text = "JetBlue",  Image="itemair3.png", SeatPitch="" },
				new ItemAir { Id = "3", Text = "HAWAIIAN", Image="itemair4.png", SeatPitch="" },
				new ItemAir { Id = "4", Text = "DELTA",  Image="itemair5.png", SeatPitch="" }
			};

			BindingContext = this;
		}

		public ItemAir CurrentLeftItem { get; set; }
		public ItemAir CurrentRightItem { get; set; }
		public bool IsNotOriginalPostion => !IsOriginalPostion;
		public bool IsOriginalPostion { get; set; } = true;
		public ObservableCollection<ItemAir> ItemsCompa { get; private set; }
		public ObservableCollection<ItemAir> ItemsCompaAll { get; private set; }
		public ObservableCollection<ItemAir> ItemsCompaPin { get; private set; }
		public Command<ItemAir> PinAirlineCmd { get; }

		private void IniteCompList()
		{
			//Or, init value from ItemsCompaAll, todo
			ItemsCompa = new ObservableCollection<ItemAir>()
			{
				new ItemAir { Id = "0", Text = "Southwest", SeatPitch="", Image="itemair1.png" },
				new ItemAir { Id = "1", Text = "VgAmerica", Image="itemair2.png", SeatPitch="" },
				new ItemAir { Id = "2", Text = "JetBlue",  Image="itemair3.png", SeatPitch="" },
				new ItemAir { Id = "3", Text = "HAWAIIAN", Image="itemair4.png", SeatPitch="" },
				new ItemAir { Id = "4", Text = "DELTA",  Image="itemair5.png", SeatPitch="" }
			};
		}

		private async void PinAirline(ItemAir obj)
		{
			IniteCompList();
			ItemsCompa.Remove(ItemsCompa.Where(i => i.Id == obj.Id).Single());
			ItemsCompaPin.Clear();
			ItemsCompaPin.Add(obj);

			uint duration = 200;

			if (IsOriginalPostion)
			{
				LeftList.ItemsSource = ItemsCompa;
				RightList.ItemsSource = ItemsCompaPin;

				await Task.WhenAll(
					LeftFrame.TranslateTo(124, 0, duration, Easing.CubicOut),
					RightFrame.TranslateTo(-124, 0, duration, Easing.CubicOut)
				);
			}
			else
			{
				RightList.ItemsSource = ItemsCompa;
				LeftList.ItemsSource = ItemsCompaPin;

				await Task.WhenAll(
					LeftFrame.TranslateTo(0, 0, duration, Easing.CubicOut),
					RightFrame.TranslateTo(0, 0, duration, Easing.CubicOut)
				);
			}

			IsOriginalPostion = !IsOriginalPostion;
			OnPropertyChanged(nameof(IsOriginalPostion));
			OnPropertyChanged(nameof(IsNotOriginalPostion));
		}
	}
}