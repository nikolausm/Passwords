using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json; 

namespace SimpleUi.Data
{
	public class PasswordService
	{
		private readonly PasswordServiceSettings _settings;
		private readonly HttpClient _client;

		public PasswordService(
			PasswordServiceSettings settings
		)
		{
			_settings = settings;
			_client = new HttpClient
			{
				BaseAddress = new Uri(_settings.BaseUrl)
			};
		}
		public Task<string[]> GetPasswordsAsync()
		{
			return Task.FromResult(
				JsonConvert.DeserializeObject<string[]>(
					_client.GetAsync(_settings.PasswordsPath)
						.GetAwaiter().GetResult()
						.Content.ReadAsStringAsync()
						.GetAwaiter().GetResult()
				)
			);

		}
		public Task<string> GetPasswordAsync()
		{
			return Task.FromResult(
				_client.GetAsync(_settings.PasswordsPath)
					.GetAwaiter().GetResult()
					.Content.ReadAsStringAsync()
					.GetAwaiter().GetResult()
			);
		}
	}
}
