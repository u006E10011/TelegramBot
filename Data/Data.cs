namespace TelegramBot.Data
{
	public class Data : IData
	{
		private static Data _instance = new();
		public static Data Instance 
		{
			get => _instance ?? new();
		}
		
		public Dictionary<string, string> _text = new()
		{
			{ "привет", "Привет" },
			{ "hello", "Hello"}
		};

		public void Add(string key, string value)
		{
			_text.Add(key, value);
		}

		public void Remove(string key)
		{
			_text.Remove(key);
		}

		public bool TryGetValue(string key, out string value)
		{
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
			return _text.TryGetValue(key, out value);
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
		}
	}
}