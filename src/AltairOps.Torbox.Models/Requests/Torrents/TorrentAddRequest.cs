using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Requests.Torrents;
/// <summary>
/// Represents the request for torrent's creation.
/// </summary>
public class TorrentAddRequest
{
    [JsonPropertyName("file")]
    public Byte[]? File { get; set; }

    [JsonPropertyName("magnet")]
    public string? Magnet { get; set; }

    [JsonPropertyName("seed")]
    public int Seed { get; set; }

    [JsonPropertyName("allow_zip")]
    public bool AllowZip { get; set; } = true;

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("as_queued")]
    public bool? AsQueued { get; set; }

    [JsonPropertyName("add_only_if_cached")]
    public bool? AddOnlyIfCached { get; set; }
}