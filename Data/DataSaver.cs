using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using TelegramBot.Core;

namespace TelegramBot.Data
{
	public class DataSaver
	{
		public static void Save(string dataName, object data)
		{
			var options = new JsonSerializerOptions()
			{
				AllowTrailingCommas = true,
				WriteIndented = true,
				DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower,
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
			};
			
			var json = JsonSerializer.Serialize(data, options);
			File.WriteAllText(Constanc.DATA_PATH + dataName, json);
			
			//System.Console.WriteLine("Data:\n" + json);
		}
	}
}