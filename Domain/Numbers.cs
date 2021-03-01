using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Domain
{
	public class Numbers
	{
		public Numbers()
		{ }

		public string Value(int minValue = 1980, int maxValue = 2100)
		=> new Random(Guid.NewGuid().GetHashCode())
			.Next(minValue, maxValue)
			.ToString();
	}
}
