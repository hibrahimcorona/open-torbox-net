using System.Collections.Specialized;

public static class NameValueCollectionExtensions
{
    public static void AddIfHasValue(this NameValueCollection collection, string name, object? value)
    {
        if (collection is null)
            return;

        if (value is null)
            return;
        
        collection.Add(name, value.ToString().ToLowerInvariant());
    }
}