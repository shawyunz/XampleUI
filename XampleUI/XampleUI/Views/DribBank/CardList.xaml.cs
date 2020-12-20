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

		public List<BankTransaction> MockTransactions() => new List<BankTransaction>()
		{
			new BankTransaction {
				Title="2",
				Type="bank",
				Amount="+123.00" },
			new BankTransaction {
				Title="2",
				Type="bank",
				Amount="+123.00" },
			new BankTransaction {
				Title="2",
				Type="bank",
				Amount="+123.00" },
			new BankTransaction {
				Title="2",
				Type="bank",
				Amount="+123.00" }
			//.....
		};

	}
}