namespace TelegramBot.Data
{
	public interface IData
	{
		public void Add(string key, string value);
		public void Remove(string key);
		public bool TryGetValue(string key, out string value);
	}
}