using System;
using Telegram.Bot.Polling;

namespace TelegramBot.Core
{
	public static class ExceptionHandler
	{
		public static async Task OnError(Exception exception, HandleErrorSource source)
		{
			await Task.Run(() => Console.WriteLine("", exception.Message));
		}
	}
}