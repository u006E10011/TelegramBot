using TelegramBot.Core;

namespace TelegramBot.Data
{
	public class TextData : Data
	{
		private TextData() : base(Value, Constanc.DATA_JSON_NAME_TEXT) { }
		static TextData()
		{
			_instance = new();
			_instance.Init();
			_instance.Save();
		}
		
		private static TextData? _instance;
		public static TextData? Instance => _instance;

		public static Dictionary<string, string> Value { get; private set; } = new();

		public new void Init()
		{
			Add("привет", "Привет");
			Add("Hello", "Hello");
		}
	}
}