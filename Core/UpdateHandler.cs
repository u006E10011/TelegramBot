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

			if (message?.Text != null)
			{
				await TextHandler(message);
				await GetImage.GetImageForURL(message);
				return;
			}
		}

		private static async Task TextHandler(Message message)
		{
			await Task.Run(() =>
			{
				System.Console.WriteLine("Input: " + message.Text);

				if (CommandHandler.GetCommand(message).Result)
					return;

				if (TextData.Instance.TryGetValue((message.Text ?? "").ToLower(), out var text))
				{
					var result = $"{message?.From?.FirstName}: {text}";
					Console.WriteLine(result);

					//await BotClient.SendMessage(message?.Chat?.Id ?? new Chat().Id, result, cancellationToken: CTS.Token);
				}
			});
		}
	}
}