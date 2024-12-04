using TelegramBot.Core;

namespace TelegramBot.Data
{
	public class Data
	{
#pragma warning disable CS8618
		public Data() { }
#pragma warning restore CS8618

		public Data(Dictionary<string, string> data, string dataJsonName, string path = "")
		{
			_value = data;
			_pathSaveResources = path;
			_dataJsonName = dataJsonName;
		}

		private Dictionary<string, string> _value = new();
		private string _pathSaveResources;
		private string _dataJsonName;

		public async Task Init()
		{
			await Task.Run(() =>
			{
				ImageData.Instance?.Init();
				GIFData.Init();
				TextData.Instance?.Init();
			});
		}

		public void Save()
		{
			DataSaver.Save(Constanc.DATA_FOLDER_PATH + _dataJsonName, _value);
		}

		#region Body
		public void Add(string key, string value)
		{
			_value.Add(key.ToLower(), _pathSaveResources + value);
		}

		public void Remove(string key)
		{
			_value.Remove(key.ToLower());
		}

		public bool TryGetValue(string key, out string value)
		{
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
			return _value.TryGetValue(key.ToLower(), out value);
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
		}
		#endregion

	}
}