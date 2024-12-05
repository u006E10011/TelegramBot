using Telegram.Bot;
using Telegram.Bot.Types;
using System.IO;

using static TelegramBot.Core.Program;

namespace TelegramBot.Core
{
	public class GetImage
	{
		public static async Task GetImageForKey(Message message)
		{
			if (Data.ImageData.Instance.TryGetValue(message.Text ?? "", out var url))
			{
				if (!System.IO.File.Exists(url))
					return;

				using (var fileStream = new FileStream(url, FileMode.Open, FileAccess.Read))
				{
					try
					{
						await BotClient.SendPhoto(message.Chat.Id, fileStream, cancellationToken: CTS.Token);
						await BotClient.DeleteMessage(message.Chat.Id, message.Id, cancellationToken: CTS.Token);
					}
					catch (Exception ex)
					{
						await BotClient.SendMessage(message.Chat.Id, $"Ошибка отправки файла: {ex.Message}", cancellationToken: CTS.Token);
					}
				}
			}
		}

		public static async Task GetRandomImage(Message message)
		{
			var path = GetRandomFilePath(Constanc.DESTINATION_PICTURE_NEKO_PATH);
			var caption = $"Picture: {GetImageIndex(path)}";

			try
			{
				using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					await BotClient.SendPhoto(message.Chat.Id,
					fileStream,
					caption: caption,
					cancellationToken: CTS.Token);
					
					GetUsernameAndPictureIndex(message, caption);
				}
			}
			catch (Exception) { }
		}

		private static void GetUsernameAndPictureIndex(Message message, string picturename)
		{
			var text = 
			$"User: {message.Chat.FirstName} {message.Chat.LastName} ({message.Chat.Username}) " +
			$"Подрочил на: {picturename}";
		 	System.Console.WriteLine(text);
		}

		public static async Task SetNameFile()
		{
			var info = new DirectoryInfo(Constanc.DESTINATION_PICTURE_NEKO_PATH);

			if (!Directory.Exists(info.FullName))
			{
				System.Console.WriteLine($"Не удалось найти директорю: {info.FullName}");
				return;
			}

			await Task.Run(() =>
			{
				var files = Directory.GetFiles(info.FullName).OrderBy(f => f).ToList();

				for (int i = 1; i <= files.Count + 1; i++)
				{
					var oldFilePath = files[i];
					var filenameWitchoutExtension = Path.GetFileNameWithoutExtension(oldFilePath);
					var extension = Path.GetExtension(oldFilePath);

					var newFilename = $"picture_{i:D1}{extension}";
					var newFilePath = Path.Combine(info.FullName, newFilename);

					try
					{
						System.IO.File.Move(oldFilePath, newFilePath);
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Ошибка переименования файла '{oldFilePath}': {ex.Message}");
					}
				}
			});

			System.Console.WriteLine("File name: " + info.Name);
		}

		private static int GetImageIndex(string path)
		{
			var fileName = Path.GetFileNameWithoutExtension(path);
			var parts = fileName.Split("_");

			if (parts.Length > 1)
			{
				if (int.TryParse(parts[1], out var index))
					return index;
				else
					return 777;
			}

			return 777;
		}
		private static string GetRandomFilePath(string deirectoryPath)
		{
			var info = new DirectoryInfo(deirectoryPath);
			var files = Directory.GetFiles(info.FullName);
			var index = new Random().Next(0, files.Length);

			if (!Directory.Exists(info.FullName))
			{
				System.Console.WriteLine($"Не удалось найти директорю: {info.FullName}");
				return string.Empty;
			}

			if (files.Length <= 0)
			{
				System.Console.WriteLine($"Директория по пути: {info.FullName} пуста");
				return string.Empty;
			}

			return files[index];
		}
	}
}