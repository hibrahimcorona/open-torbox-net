using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Requests.Torrents;

internal class TorrentCheckCachedRequest
{
	[JsonPropertyName("hash")]
	public string? Hash { get; set; }

	[JsonPropertyName("format")]
	public string? Format { get; set; }

	[JsonPropertyName("list_files")]
	public bool ListFiles { get; set; } = false;
}