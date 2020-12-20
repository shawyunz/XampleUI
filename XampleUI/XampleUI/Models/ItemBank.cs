namespace XampleUI.Models
{
	public class BankCard
	{
		public string CardCode { get; set; }
		public string CardHolder { get; set; }
		public string CardNumber { get; set; }
		public string CardImageA { get; set; }
		public string CardImageB { get; set; }
	}

	public class BankTransaction
	{
		public string Amount { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
	}
}