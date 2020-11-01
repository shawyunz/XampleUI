using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XampleUI.Models;

namespace XampleUI.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		private readonly List<Item> items;
		private readonly List<Item> grocItems;
		private readonly List<ItemCart> grocCartItems;

		public MockDataStore()
		{
			items = new List<Item>()
			{
				new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.",  Image="item1.png" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.", Image="item2.png" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.",  Image="item3.png" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.", Image="item4.png" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description.",  Image="item1.png" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.",  Image="item2.png" }
			};

			grocItems = new List<Item>()
			{
				new Item { Id = Guid.NewGuid().ToString(), Text = "La Vie", Description="Les Framboises 60g",  Image="grocs_item0.png", Price=8.99 },
				new Item { Id = Guid.NewGuid().ToString(), Text = "La Vie", Description="Les Framboises 60g", Image="grocs_item0.png", Price=8.99 },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Seggiano Organic Tagliatelle", Description="500g",  Image="grocs_item1.png", Price=7.99 },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Rummo Fusilli No 48 Pasta", Description="500g", Image="grocs_item2.png", Price=14.99 },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Biona organic White Spelt Fusilli", Description="500g",  Image="grocs_item3.png", Price=3.69 },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Seggiano Organic Tagliatelle", Description="500g",  Image="grocs_item1.png", Price=7.99 }
			};

			grocCartItems = new List<ItemCart>();
		}

		public async Task<bool> AddItemAsync(Item item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> AddItemToCartAsync(ItemCart item)
		{
			grocCartItems.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}

		public async Task<Item> GetGrocAsync(string id)
		{
			return await Task.FromResult(grocItems.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetGrocsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(grocItems);
		}

		public async Task<IEnumerable<Item>> GetGrocsCartAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(grocCartItems);
		}
	}
}