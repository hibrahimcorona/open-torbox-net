using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Responses.Torrents;

/// <summary>
/// Represents the response of the add torrent operation.
/// </summary>
public class TorrentAddResponse
{
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    [JsonPropertyName("torrent_id")]
    public long? TorrentId { get; set; }

    [JsonPropertyName("auth_id")]
    public string? AuthId { get; set; }
}