using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Requests.Torrents;

/// <summary>
/// Represents the request to get the download link for the torrent. <br/>
/// Default set to zip the link.
/// </summary>
public class TorrentRequestDownloadRequest
{
    [JsonPropertyName("torrent_id")]
    public string? TorrentId { get; set; }

    [JsonPropertyName("file_id")]
    public string? FileId { get; set; }

    [JsonPropertyName("zip_link")]
    public bool ZipLink { get; set; } = true;

    [JsonPropertyName("user_ip")]
    public string? UserIp { get; set; }

    [JsonPropertyName("redirect")]
    public bool? Redirect { get; set; }

    [JsonPropertyName("append_name")]
    public bool? AppendName { get; set; }
}