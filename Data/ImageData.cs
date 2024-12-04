using TelegramBot.Core;
using System.IO;

namespace TelegramBot.Data
{
	public static class ImageData
	{
		public static void Init()
		{
			Add("logo", "logo.jpg");
			Add("logoChat", "ChatLogo.jpg");
		}
		
		private static void Add(string key, string name)
		{
			Data.Add(key, Constanc.DESTINATION_IMAGE_PATH + name);
		}
		
	}
}