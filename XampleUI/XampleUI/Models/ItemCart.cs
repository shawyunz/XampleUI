namespace XampleUI.Models
{
	public class ItemCart : Item
	{
		public int Quantity { get; set; }

		public ItemCart (Item item)
		{
			Id = item.Id;
			Image = item.Image;
			Description = item.Description;
			Price = item.Price;
			Text = item.Text;
		}
	}
}