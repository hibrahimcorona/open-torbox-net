using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Requests.Torrents;

public class TorrentControlRequest
{
    [JsonPropertyName("torrent_id")]
    public long? TorrentId { get; set; }

    [JsonPropertyName("operation")]
    public ControlTorrentOperation ControlTorrentOperation { get; set; }

    [JsonPropertyName("all")]
    public bool All { get; set; } = false;
}