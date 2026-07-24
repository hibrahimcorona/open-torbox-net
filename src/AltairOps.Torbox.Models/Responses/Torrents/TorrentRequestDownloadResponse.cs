using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Responses.Torrents;

/// <summary>
/// Represents the response for the download link.
/// </summary>
public class TorrentRequestDownloadResponse
{
    [JsonPropertyName("data")]
    public string? Data { get; set; }
}