using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Responses.Torrents;

/// <summary>
/// Represents a cached torrent item in the response for checking if a torrent is cached in TorBox.
/// </summary>
public class TorrentCheckCachedItem
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("size")]
	public long? Size { get; set; }

	[JsonPropertyName("hash")]
	public string? Hash { get; set; }

	[JsonPropertyName("files")]
	public List<TorrentFile>? Files { get; set; }
}

/// <summary>
/// Represents a response containing a list of cached torrent items in TorBox.
/// </summary>
public class TorrentCheckCachedListResponse : List<TorrentCheckCachedItem?>
{

}

/// <summary>
/// Represents a response containing a dictionary of cached torrent items in TorBox, where the key is the torrent hash and the value is the corresponding cached torrent item.
/// </summary>
public class TorrentCheckCachedObjectResponse : Dictionary<string, TorrentCheckCachedItem?>
{

}
