using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XampleUI.ViewModels
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public class ItemDetailViewModel : BaseViewModel
	{
		private string itemId;
		private string text;
		private string image;
		private string description;
		public string Id { get; set; }

		public string Text
		{
			get => text;
			set => SetProperty(ref text, value);
		}

		public string Image
		{
			get => image;
			set => SetProperty(ref image, value);
		}

		public string Description
		{
			get => description;
			set => SetProperty(ref description, value);
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

		public async void LoadItemId(string itemId)
		{
			try
			{
				var item = await DataStore.GetItemAsync(itemId);
				Id = item.Id;
				Text = item.Text;
				Description = item.Description;
				Image = item.Image;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Item");
			}
		}
	}
}