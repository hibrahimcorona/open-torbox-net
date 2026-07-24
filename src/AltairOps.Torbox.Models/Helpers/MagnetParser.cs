using System.Text.RegularExpressions;

namespace AltairOps.Torbox.Models.Helpers;

/// <summary>
/// A helper class for parsing magnet links and extracting the torrent hash.
/// </summary>
internal class MagnetParser
{
	private static readonly Regex _magnetHashRegex = new(
		@"xt=urn:btih:([a-fA-F0-9]{40}|[a-zA-Z2-7]{32})",
		RegexOptions.Compiled | RegexOptions.IgnoreCase);

	public static string? ExtractHash(string magnetLink)
	{
		if (string.IsNullOrWhiteSpace(magnetLink))
			return null;

		var match = _magnetHashRegex.Match(magnetLink);
		return match.Success ? match.Groups[1].Value : null;
	}
}
