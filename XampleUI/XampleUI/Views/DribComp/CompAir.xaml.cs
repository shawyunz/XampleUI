using System.Collections.Generic;
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

			ItemsComparison = new ObservableCollection<ItemAir>(MockData());
			ItemsAll = new ObservableCollection<ItemAir>(MockData());
			ItemsCompaPin = new ObservableCollection<ItemAir>();

			BindingContext = this;

			//PIN JetBlue to start
			PinAirline(new ItemAir
			{
				Id = "2",
				Text = "JetBlue",
				Image = "itemair3.png",
				SeatPitch = "33",
				SeatWidth = "18",
				Wifi = "icon_check.png",
				Entertainment = "icon_check.png",
				InSeatPower = "icon_check.png",
				SeatSelection = "icon_check.png",
				LoyaltyTiers = "1",
				CheckedBags = "icon_dollar.png",
				PointsExpiration = "Never"
			});
		}

		public ItemAir CurrentLeftItem { get; set; }
		public ItemAir CurrentRightItem { get; set; }
		public bool IsNotOriginalPostion => !IsOriginalPostion;
		public bool IsOriginalPostion { get; set; } = true;
		public ObservableCollection<ItemAir> ItemsAll { get; private set; }
		public ObservableCollection<ItemAir> ItemsCompaPin { get; private set; }
		public ObservableCollection<ItemAir> ItemsComparison { get; private set; }
		public Command<ItemAir> PinAirlineCmd { get; }

		private void ChangeState()
		{
			IsOriginalPostion = !IsOriginalPostion;
			OnPropertyChanged(nameof(IsOriginalPostion));
			OnPropertyChanged(nameof(IsNotOriginalPostion));
		}

		private List<ItemAir> MockData() => new List<ItemAir>()
		{
			new ItemAir {
				Id = "0",
				Text = "Southwest",
				Image="itemair1.png",
				SeatPitch="32",
				SeatWidth="17",
				Wifi="icon_dollar.png",
				Entertainment="",
				InSeatPower="",
				SeatSelection="",
				LoyaltyTiers="2",
				CheckedBags="icon_check.png",
				PointsExpiration="24-month" },
			new ItemAir { Id = "1",
				Text = "VgAmerica",
				Image="itemair2.png",
				SeatPitch="33",
				SeatWidth="17",
				Wifi="icon_check.png",
				Entertainment="icon_check.png",
				InSeatPower="icon_check.png",
				SeatSelection="icon_check.png",
				LoyaltyTiers="2",
				CheckedBags="icon_dollar.png",
				PointsExpiration="18-month" },
			new ItemAir { Id = "2",
				Text = "JetBlue",
				Image="itemair3.png",
				SeatPitch="33",
				SeatWidth="18",
				Wifi="icon_check.png",
				Entertainment="icon_check.png",
				InSeatPower="icon_check.png",
				SeatSelection="icon_check.png",
				LoyaltyTiers="1",
				CheckedBags="icon_dollar.png",
				PointsExpiration="Never" },
			new ItemAir { Id = "3",
				Text = "HAWAIIAN",
				Image="itemair4.png",
				SeatPitch="30",
				SeatWidth="18",
				Wifi="",
				Entertainment="",
				InSeatPower="",
				SeatSelection="icon_check.png",
				LoyaltyTiers="2",
				CheckedBags="icon_dollar.png",
				PointsExpiration="18-month" },
			new ItemAir { Id = "4",
				Text = "DELTA",
				Image="itemair5.png",
				SeatPitch="32",
				SeatWidth="17",
				Wifi="icon_dollar.png",
				Entertainment="",
				InSeatPower="icon_check.png",
				SeatSelection="icon_dollar.png",
				LoyaltyTiers="2",
				CheckedBags="icon_dollar.png",
				PointsExpiration="Never" },
		};

		private async void PinAirline(ItemAir obj)
		{
			ItemsComparison = new ObservableCollection<ItemAir>(MockData());
			ItemsComparison.Remove(ItemsComparison.Where(i => i.Id == obj.Id).Single());
			ItemsCompaPin.Clear();
			ItemsCompaPin.Add(obj);

			uint duration = 200;

			if (IsOriginalPostion)
			{
				LeftList.ItemsSource = ItemsComparison;
				RightList.ItemsSource = ItemsCompaPin;
				ChangeState();

				await Task.WhenAll(
					LeftFrame.TranslateTo(124, 0, duration, Easing.CubicIn),
					RightFrame.TranslateTo(-124, 0, duration, Easing.CubicIn)
				);
			}
			else
			{
				RightList.ItemsSource = ItemsComparison;
				LeftList.ItemsSource = ItemsCompaPin;
				ChangeState();

				await Task.WhenAll(
				LeftFrame.TranslateTo(0, 0, duration, Easing.CubicIn),
					RightFrame.TranslateTo(0, 0, duration, Easing.CubicIn)
				);
			}
		}
	}
}