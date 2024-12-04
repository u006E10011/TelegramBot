using Telegram.Bot;
using Telegram.Bot.Types;

using static TelegramBot.Core.Program;

namespace TelegramBot.Core
{
	public class GetImage
	{
		public static async Task GetImageForURL(Message message)
		{
			if (Data.Data.TryGetValue(message.Text ?? "", out var url))
			{
				if (!System.IO.File.Exists(url))
					return;

				using (var fileStream = new FileStream(url, FileMode.Open, FileAccess.Read))
				{
					try
					{
						await BotClient.SendPhoto(message.Chat.Id, fileStream);
					}
					catch (Exception ex)
					{
						await BotClient.SendMessage(message.Chat.Id, $"Ошибка отправки файла: {ex.Message}");
					}
				}
			}
		}

	}
}