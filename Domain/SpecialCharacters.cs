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
		=> new Random(Guid.NewGuid().GetHashCode()).Next() % 2 == 0
				? "?"
				: "!";
	}
}
