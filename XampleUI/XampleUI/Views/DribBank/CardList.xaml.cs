using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleUI.Models;

namespace XampleUI.Views.DribBank
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardList : ContentPage
	{
		public CardList()
		{
			InitializeComponent();
			BindingContext = this;
		}


		public Command<BankCard> ItemTapped => new Command<BankCard>(OnItemSelected);

		private async void OnItemSelected(BankCard item)
		{
			if (item == null)
				return;

			// This will push the ItemDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(CardTransaction)}?{nameof(CardTransaction.ItemId)}={item.CardCode}");
		}

		public ObservableCollection<BankCard> BankCardList => new ObservableCollection<BankCard>(MockCards());

		public List<BankCard> MockCards() => new List<BankCard>()
		{
			new BankCard {
				CardCode="2",
				CardHolder="icon_check.png",
				CardNumber="24-month",
				CardImageA="bankcard1a",
				CardImageB="bankcard1b"},
			new BankCard {
				CardCode="2",
				CardHolder="icon_check.png",
				CardNumber="24-month",
				CardImageA="bankcard2a",
				CardImageB="bankcard2b"},
			new BankCard {
				CardCode="2",
				CardHolder="icon_check.png",
				CardNumber="24-month",
				CardImageA="bankcard3a",
				CardImageB="bankcard3b"}
		};

	}
}