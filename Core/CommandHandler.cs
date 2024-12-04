using System.Diagnostics.CodeAnalysis;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Data;
using static TelegramBot.Core.Program;

namespace TelegramBot.Core
{
	public class CommandHandler
	{
		private const string INFO =
		@"Разработчик: @u006E10011
		Канал: @u8bitinc
		Чат: @u8bitincchat";

		private const string GREETING =
		@"Привет, этот бот находится в стадии разработки
		Используй команду /help, чтобы получить список доступных комманд";

		public const string GET_COMMAND =
		@"Список команд:
		/start - Приветсвие
		/info - Информация о боте
		/help - Выводит список команд";

		public static async Task<bool> GetCommand(Message message)
		{
			switch (message.Text)
			{
				case "/start":
					await Message(message.Chat, GREETING);
					return true;
				case "/info":
					await Message(message.Chat, INFO);
					return true;
				case "/help":
					await Message(message.Chat, GET_COMMAND);
					return true;
				case "/addText":
					System.Console.WriteLine("Null command add text");
					return true;
			}

			return false;
		}

		private static async Task Message(Chat chat, string message)
		{
			await BotClient.SendMessage(chat.Id, message, ParseMode.Html, protectContent: true);
		}
	}
}