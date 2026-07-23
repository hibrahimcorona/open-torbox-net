using AltairOps.Torbox.Models.Requests;
using AltairOps.Torbox.Models.Responses.Torrents;

namespace AltairOps.Torbox.Models.Client.Torrent;

/// <summary>
/// Represents a torrent client that can be used to interact with torrents.
/// </summary>
public interface ITorrentClient
{
	public Task<List<TorrentListResponse>> GetAsync(TorrentListRequest request);
}
