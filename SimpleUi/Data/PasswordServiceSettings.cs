using System;

namespace SimpleUi.Data
{
	public class PasswordServiceSettings
	{
		public PasswordServiceSettings(string baseUrl, string passwordPath, string passwordsPath)
		{
			BaseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
			PasswordPath = passwordPath ?? throw new ArgumentNullException(nameof(passwordPath));
			PasswordsPath = passwordsPath ?? throw new ArgumentNullException(nameof(passwordsPath));
		}

		public string BaseUrl { get; }
		public string PasswordPath { get; }
		public string PasswordsPath { get; }
	}
}