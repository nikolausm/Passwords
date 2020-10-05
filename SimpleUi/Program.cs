
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using System;

namespace SimpleUi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(
			string[] args
		) {
			return Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(
				(hostContext, builder) =>
				{
					if (hostContext.HostingEnvironment.IsDevelopment())
					{
						builder.AddUserSecrets("Passwords");
					}

					if (hostContext.HostingEnvironment.IsProduction())
					{
						var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
						builder.AddAzureKeyVault(
							keyVaultEndpoint,
							new DefaultAzureCredential()
						);
					}
				}
			).ConfigureWebHostDefaults(
				webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				}
			);
		}
	}
}
