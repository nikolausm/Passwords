using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Domain.Extensions;

namespace Domain
{
	public class Password
	{
		private readonly Words _words;
		public Password(Words words)
		{
			_words = words;
		}

		public string[] Values(
			uint count = 3,
			byte wordCount = 3,
			byte minWordLength = 3,
			byte maxWordLength = 7,
			uint maxTriesPerPassword = 512
		)
		{
			#region validation
			if (maxTriesPerPassword < 1)
			{
				throw new ArgumentException("Maximum tries per password must be greater than 1.");
			}
			if (minWordLength < 3)
			{
				throw new ArgumentException("Minimum word length must be greater than 2.");
			}
			if (minWordLength > 7)
			{
				throw new ArgumentException("Minimum word length must be less than 7.");
			}
			if (maxWordLength > 12)
			{
				throw new ArgumentException("Maximum word length must be less than 12.");
			}
			if (maxWordLength < 3)
			{
				throw new ArgumentException("Minimum max word length must be greater than 2.");
			}
			if (minWordLength > maxWordLength)
			{
				throw new ArgumentException("Minimum word length must be greater than the maximum word length.");
			}
			#endregion

			int tries = 0;
			var values = new ConcurrentDictionary<string, int>();
			while (values.Count < count && tries < maxTriesPerPassword * count)
			{
				tries++;
				values.TryAdd(
					_words.Values(wordCount, minWordLength, 7).ToString(" ")
					+ " " + (new Numbers().Value())
					+ (new SpecialCharacters().Value()),
					tries
				);
			}

			if (maxTriesPerPassword * count == tries)
			{
				throw new InvalidOperationException(
					"I was not able to generate all request passwords."
				);
			}

			return values.Keys.Take(count).ToArray();
		}
	}
}
