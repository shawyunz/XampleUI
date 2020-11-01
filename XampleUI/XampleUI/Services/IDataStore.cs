using System.Collections.Generic;
using System.Threading.Tasks;
using XampleUI.Models;

namespace XampleUI.Services
{
	public interface IDataStore<T>
	{
		Task<bool> AddItemAsync(T item);

		Task<bool> UpdateItemAsync(T item);

		Task<bool> DeleteItemAsync(string id);

		Task<T> GetItemAsync(string id);

		Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

		Task<T> GetGrocAsync(string id);

		Task<IEnumerable<T>> GetGrocsAsync(bool forceRefresh = false);

		Task<bool> AddItemToCartAsync(ItemCart item);
		Task<IEnumerable<ItemCart>> GetGrocsCartAsync(bool forceRefresh = false);
	}
}