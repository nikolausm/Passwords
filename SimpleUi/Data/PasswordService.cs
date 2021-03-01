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

		public async Task<string[]> GetPasswordsAsync()
		=> JsonConvert.DeserializeObject<string[]>(
			await (await _client.GetAsync(_settings.PasswordsPath))
				.Content
				.ReadAsStringAsync()
		);

		public async Task<string[]> GetPasswordAsync()
		=> JsonConvert.DeserializeObject<string[]>(
			await (await _client.GetAsync(_settings.PasswordsPath))
				.Content
				.ReadAsStringAsync()
		);
	}
}
