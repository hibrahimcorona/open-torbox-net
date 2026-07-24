public static class MultipartFormDataContenExtensions
{
	public static void AddIfHasValue(this MultipartFormDataContent content, string name, object? value)
	{
		if (content is null)
			return;

		if (value is null)
			return;

		content.Add(new StringContent(value.ToString().ToLowerInvariant()), name);
	}
}