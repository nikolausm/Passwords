using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Domain
{
	public class SpecialCharacters
	{
		public SpecialCharacters()
		{ }

		public string Value()
		{
			var random = new Random(Guid.NewGuid().GetHashCode());
			return random.Next() % 2 == 0
				? "?"
				: "!";
		}
	}
}
