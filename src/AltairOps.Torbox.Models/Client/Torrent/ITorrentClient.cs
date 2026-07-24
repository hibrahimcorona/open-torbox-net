using AltairOps.Torbox.Models.Requests.Torrents;
using AltairOps.Torbox.Models.Responses;
using AltairOps.Torbox.Models.Responses.Torrents;

namespace AltairOps.Torbox.Models.Client.Torrent;

/// <summary>
/// Represents a torrent client that can be used to interact with torrents.
/// </summary>
public interface ITorrentClient
{
	public Task<TorBoxResponse<List<TorrentListResponse?>>> ListTorrents(TorrentListRequest request, CancellationToken cancellationToken = default);

	public Task<TorBoxResponse<TorrentAddResponse?>> AddTorrent(TorrentAddRequest request, CancellationToken cancellationToken = default);
}
