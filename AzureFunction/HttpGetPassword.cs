using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Domain;
using System.Linq;

namespace AzureFunction
{
	public static class HttpGetPassword
	{
		[FunctionName("HttpGetPassword")]
		public static async Task<IActionResult> Run(
			[HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
			ILogger log,
			ExecutionContext context
		)
		{
			log.LogInformation("C# HTTP trigger function processed a request.");
			return new OkObjectResult(
				new Password(
					new Words(
						Path.Combine(
							context.FunctionAppDirectory,
							"deutsch.txt"
						)
					)
				).Values(
					count: 1,
					wordCount: 3,
					minWordLength: 3,
					maxWordLength: 7,
					maxTriesPerPassword: 256
				).First()
			);
		}
	}
}
