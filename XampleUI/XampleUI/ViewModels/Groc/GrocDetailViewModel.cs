using System;
using System.Diagnostics;
using Xamarin.Forms;
using XampleUI.Models;

namespace XampleUI.ViewModels.Groc
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	internal class GrocDetailViewModel : BaseViewModel
	{
		private string itemId;
		private int quantity;
		private Item item;
		public Command AddItemCommand => new Command(OnAddItem);

		public int Quantity
		{
			get => quantity;
			set => SetProperty(ref quantity, value);
		}

		public Item CurrentItem
		{
			get => item;
			set => SetProperty(ref item, value);
		}

		public string ItemId
		{
			get
			{
				return itemId;
			}
			set
			{
				itemId = value;
				LoadItemId(value);
			}
		}

		private async void OnAddItem(object obj)
		{
			var cartItem = new ItemCart(CurrentItem)
			{
				Quantity = 3
			};
			await DataStore.AddItemToCartAsync(cartItem);
		}

		public async void LoadItemId(string itemId)
		{
			try
			{
				CurrentItem = await DataStore.GetGrocAsync(itemId);
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}