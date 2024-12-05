using Telegram.Bot;
using Telegram.Bot.Types;

using static TelegramBot.Core.Constanc;

namespace TelegramBot.Core
{
	public class Program
	{
		public static User Me { get; private set; } = new();
		public static TelegramBotClient BotClient { get; private set; } = new(TOKEN);
		public static CancellationTokenSource CTS { get; private set; } = new();

		private static async Task Main()
		{
			var program = new Program();
			await program.Init();
		}

		private async Task Init()
		{
			CTS = new CancellationTokenSource();
			BotClient = new(TOKEN, cancellationToken: CTS.Token);
			Me = await BotClient.GetMe();

			BotClient.OnError += ExceptionHandler.OnError;
			BotClient.OnUpdate += UpdateHandler.OnUpdate;
			Exit();
		}

		private void Exit()
		{
			while (Console.ReadKey().Key == ConsoleKey.Escape)
			{
				System.Console.WriteLine("Disable bot");
				CTS.Cancel();
			}
		}
	}
}