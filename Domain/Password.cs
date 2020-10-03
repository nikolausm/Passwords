using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;

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
			int count = 3,
			byte wordCount = 3,
			byte minWordLength = 3,
			byte maxWordLength = 7,
			int maxTries = 1024
		)
		{
			
			var words = _words;
			int tries = 0;
			var values = new ConcurrentDictionary<string, int>();
			while (values.Count < count && tries < maxTries)
			{
				Parallel.For(
					0,
					4,
					(index, state) => {
						tries++;
						values.TryAdd(
							words.Values(wordCount, minWordLength, maxWordLength).ToString(" ")
							+ " " + (new Numbers().Value())
							+ (new SpecialCharacters().Value()),
							tries
						);
					}
				);
			}

			return values.Keys.Take(count).ToArray();
		}
	}
}
