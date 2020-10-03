using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Domain
{
	public class Words
	{
		public Words(string fileName = "deutsch.txt")
		{
			_words = new Lazy<List<string>>(
				ReadFileToList(Path.Combine(Directory.GetCurrentDirectory(), fileName))
			, true);
		}

		private static Func<List<string>> ReadFileToList(string fileName)
		{
			return () =>
			{
				using(var reader = new StreamReader(fileName))
				{
					var result = new List<string>();
					while(reader.Peek() >= 0)
					{
						result.Add(reader.ReadLine());
					}
					return result;
				}
			};
		}

		public string[] Values(byte count, byte minLength = 3, byte maxLength = 10)
		{
			var hashSet = new HashSet<string>();
			var random = new Random(Guid.NewGuid().GetHashCode());
			var wordNumber = 0;
			do
			{
				var randomNumber = random.Next();
				if(randomNumber < _words.Value.Count)
				{
					var word = _words.Value[randomNumber];

					if(word.Length < minLength)
					{
						continue;
					}

					if(word.Length > maxLength)
					{
						continue;
					}

					if(Char.IsUpper(word[0]) && wordNumber % 2 == 1)
					{
						continue;
					}
					if(!Char.IsUpper(word[0]) && wordNumber % 2 == 0)
					{
						continue;
					}

					hashSet.Add(word);
					wordNumber++;
				}
			}
			while(hashSet.Count < count);

			return hashSet.ToArray();
		}

		public Lazy<List<string>> _words { get; }
	}
}
