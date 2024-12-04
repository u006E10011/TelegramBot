using TelegramBot.Core;

namespace TelegramBot.Data
{
	public static class Data
	{
		public static Dictionary<string, string> Value { get; private set; } = new();

		public static async Task Init()
		{
			await Task.Run(() =>
			{
				ImageData.Init();
				GIFData.Init();
				TextData.Init();

				DataSaver.Save(Constanc.DATA_NAME, Value);
			});
		}

		public static void Add(string key, string value)
		{
			Value.Add(key.ToLower(), value);
		}

		public static void Remove(string key)
		{
			Value.Remove(key.ToLower());
		}

		public static bool TryGetValue(string key, out string value)
		{
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
			return Value.TryGetValue(key.ToLower(), out value);
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
		}
	}
}