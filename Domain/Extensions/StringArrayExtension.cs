namespace Domain.Extensions
{
	public static class StringArrayExtension
	{
		public static string ToString(this string[] input, string separator)
		=> System.String.Join(separator, input);
	}
}