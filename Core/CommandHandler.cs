using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

using static TelegramBot.Core.Program;
using static TelegramBot.Core.Constanc;

namespace TelegramBot.Core
{
	public class CommandHandler
	{
		private const string INFO =
		@"Разработчик: @u006E10011
		Канал: @u8bitinc
		Чат: @u8bitincchat";

		private const string GREETING =
		@"В данный момент бот находится в стадии разработки
		Используй команду /help, чтобы получить список доступных комманд";

		public const string GET_COMMAND =
		@"Список команд:
		/start - Приветсвие
		/info - Информация о боте
		/help - Выводит список команд
		/picture - случайная пикча";

		public static async Task<bool> GetCommand(Message message)
		{
			switch (message.Text)
			{
				case "/start":
					await Message(message, GREETING);
					return true;
				case "/info":
					await BotClient.SendMessage(message.Chat, INFO,
						replyMarkup: new InlineKeyboardMarkup()
						.AddButtons(
							InlineKeyboardButton.WithUrl("Канал", CHANEL),
							InlineKeyboardButton.WithUrl("Чат", CHAT)));

					await BotClient.DeleteMessage(message.Chat.Id, message.Id);
					return true;
				case "/help":
					await Message(message, GET_COMMAND);
					return true;
				case "/picture":
					await GetImage.GetRandomImage(message);
					//await BotClient.DeleteMessage(message.Chat.Id, message.Id);
					return true;

			}

			return false;
		}

		private static async Task Message(Message message, string msg)
		{
			await BotClient.SendMessage(message.Chat.Id, msg, ParseMode.Html, protectContent: true);
			await BotClient.DeleteMessage(message.Chat.Id, message.Id);
		}
	}
}