using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XampleUI.Models;

namespace XampleUI.Views.DribBank
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardTransaction : ContentPage
	{
		private bool isBack;
		private bool isFliping = false;
		private string itemId;

		private bool startFromFront;

		public CardTransaction()
		{
			InitializeComponent();
		}

		public ObservableCollection<BankCard> BankCardList => new ObservableCollection<BankCard>(MockCards());

		public ObservableCollection<BankTransaction> BankTransList => new ObservableCollection<BankTransaction>(MockTransactions());

		public bool IsFront { get; set; }

		public string ItemId
		{
			get
			{
				return itemId;
			}
			set
			{
				itemId = value;
				LoadTrans(value);
			}
		}

		public void LoadTrans(string itemId)
		{
			try
			{
				var item = BankCardList.FirstOrDefault(x => x.CardCode == itemId);
				//get trans list
				//BankTransList
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}

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

		private void FlipCardByDragging(View view1, View view2, double rotation)
		{
			int angle = Math.Abs(((int)Math.Round(rotation)) % 360);

			if (angle <= 90 || angle > 270)
			{
				view1.IsVisible = true;
				view2.IsVisible = false;
				view1.RotationX = rotation;
			}
			else
			{
				view2.IsVisible = true;
				view1.IsVisible = false;
				view2.RotationX = rotation - 180;
			}
		}

		private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
		{
			var offset = e.TotalY;

			if (e.StatusType.ToString() == "Started" || e.StatusType.ToString() == "Completed")
			{
				startFromFront = IsFront;
				Card2View.RotationX = IsFront ? -270 : 0;
				Card1View.RotationX = !IsFront ? -270 : 0;
			}

			if (startFromFront)
			{
				FlipCardByDragging(Card1View, Card2View, offset * -2);
			}
			else
			{
				FlipCardByDragging(Card2View, Card1View, offset * -2);
			}
		}

		private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
		{

		}
	}
}