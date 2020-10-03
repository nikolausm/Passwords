using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain;

namespace Passwords.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PasswordsController : ControllerBase
	{

		private readonly ILogger<PasswordsController> _logger;
		private readonly Words _words;

		public PasswordsController(ILogger<PasswordsController> logger, Words words)
		{
			_logger = logger;
			_words = words;
		}

		[HttpGet]
		public string[] Get(int count = 32, byte words = 3, byte minWordLength = 3, byte maxWordLength = 7)
		{
			return  new Password(_words).Values(count, minWordLength, maxWordLength);
		}
	}
}
