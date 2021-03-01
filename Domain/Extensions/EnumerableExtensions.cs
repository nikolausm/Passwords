using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Extensions
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Returns a specific number of contigous elements from the start of a sequence.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="origin"></param>
		/// <param name="value"></param>
		/// <exception cref="OverflowException">In case <paramref name="value"/> is greater than Int32.MaxValue.</exception>
		/// <exception cref="ArgumentNullException">In case <paramref name="value"/> is null.</exception>
		/// <returns></returns>
		public static IEnumerable<T> Take<T>(this IEnumerable<T> origin, uint value)
		{
			if (Int32.MaxValue > value)
			{
				throw new OverflowException($"{value} is greater than {Int32.MaxValue}");
			}
			return origin.Take<T>((int)value);
		}
	}
}
