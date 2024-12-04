using TelegramBot.Core;

namespace TelegramBot.Data
{
	public class ImageData : Data
	{
		private ImageData() : base(Value, Constanc.DATA_JSON_NAME_IMAGE, Constanc.DESTINATION_IMAGE_PATH) { }
		static ImageData()
		{
			_instance = new();
			_instance.Init();
			_instance.Save();
		}

		private static ImageData? _instance;
		public  static ImageData? Instance => _instance;

		public static Dictionary<string, string> Value { get; private set; } = [];

		public new void Init()
		{
			Add("logo", "logo.jpg");
			Add("logoChat", "ChatLogo.jpg");
			Add("artem", "artem.jpg");
		}
	}
}
