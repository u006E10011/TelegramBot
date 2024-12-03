using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Data;

using static TelegramBot.Core.Program;

namespace TelegramBot.Core
{
	public static class UpdateHandler
	{
		public static async Task OnUpdate(Update update)
		{
			var message = update.Message;

			if (message.Text != null)
			{
				await TextHandler(message, TextData.Instance);
				return;
			}
		}

		private static async Task TextHandler(Message message, TelegramBot.Data.Data data)
		{
			if (data.TryGetValue((message.Text ?? "").ToLower(), out var text))
			{
				var result = $"{message.From.FirstName}: {text}";
				Console.WriteLine(result);
				
				await BotClient.SendMessage(message.Chat.Id, result, cancellationToken: CTS.Token);
			}
		}
	}
}