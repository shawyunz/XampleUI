using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using XampleUI.Models;
using XampleUI.Views.DribGrocs;

namespace XampleUI.ViewModels.Groc
{
	public class GrocsViewModel : BaseViewModel
	{
		private Item _selectedItem;

		public GrocsViewModel()
		{
			Title = "Browse";
			Grocs = new ObservableCollection<Item>();
			GrocsCart = new ObservableCollection<ItemCart>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			ItemTapped = new Command<Item>(OnItemSelected);
		}

		public double CartAmount { get; private set; }
		public int CartCount => GrocsCart?.Count ?? 0;
		public ObservableCollection<Item> Grocs { get; }
		public ObservableCollection<ItemCart> GrocsCart { get; set; }
		public bool HasCart { get; set; }
		public Command<Item> ItemTapped { get; }
		public Command LoadItemsCommand { get; }

		public Item SelectedItem
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);
				OnItemSelected(value);
			}
		}

		public async void OnAppearing()
		{
			IsBusy = true;
			SelectedItem = null;

			GrocsCart.Clear();
			var items = await DataStore.GetGrocsCartAsync();
			if (items is null)
			{
				return;
			}
			foreach (var item in items)
			{
				GrocsCart.Add(item);
			}

			OnPropertyChanged(nameof(CartCount));

			var amount = GrocsCart?.Sum(x => x.Price * x.Quantity) ?? 0;
			CartAmount = amount < 40 ? amount + 30 : amount;
			OnPropertyChanged(nameof(CartAmount));
		}

		private async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;

			try
			{
				Grocs.Clear();
				var items = await DataStore.GetGrocsAsync(true);
				foreach (var item in items)
				{
					Grocs.Add(item);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}

		private async void OnItemSelected(Item item)
		{
			if (item == null)
				return;

			// This will push the ItemDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(GrocDetail)}?{nameof(GrocDetailViewModel.ItemId)}={item.Id}");
		}
	}
}