using AltairOps.Torbox.Models.Enums;
using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Requests.Torrents;

/// <summary>
/// Represents a request to check if a torrent is cached in TorBox.
/// </summary>
public class TorrentCheckCachedRequest
{
	[JsonPropertyName("hash")]
	public string? Hash { get; set; }

	[JsonPropertyName("format")]
	public Format? Format { get; set; }

	[JsonPropertyName("list_files")]
	public bool ListFiles { get; set; } = false;
}