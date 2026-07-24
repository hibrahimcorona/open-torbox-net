using AltairOps.Torbox.Models.Requests.Torrents;
using AltairOps.Torbox.Models.Responses;
using AltairOps.Torbox.Models.Responses.Torrents;

namespace AltairOps.Torbox.Models.Client.Torrent;

/// <summary>
/// Represents a torrent client that can be used to interact with torrents.
/// </summary>
public interface ITorrentClient
{
	/// <summary>
	/// Lists the torrents available in your TorBox account.
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task<TorBoxResponse<List<TorrentListResponse?>>> GetListTorrents(TorrentListRequest request, CancellationToken cancellationToken = default);

	/// <summary>
	/// Adds a torrent to your TorBox account.
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task<TorBoxResponse<TorrentAddResponse?>> PostAddTorrent(TorrentAddRequest request, CancellationToken cancellationToken = default);

	/// <summary>
	/// Obtains a download link from TorBox.
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task<TorBoxResponse<string?>> GetDownloadLink(TorrentRequestDownloadRequest request, CancellationToken cancellationToken = default);

	/// <summary>
	/// Operation for control torrent. <br/>
	/// There are 3 types of operations: <br/>
	/// Reannounce reannounces the torrent to get new peers. <br/>
	/// Delete deletes the torrent from the client and your account permanently.<br/>
	/// Resume resumes a paused torrent.<br/>
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task<TorBoxResponse<ControlTorrentResponse?>> PostControlTorrent(TorrentControlRequest request, CancellationToken cancellationToken = default);

	/// <summary>
	/// Checks if a torrent is cached in TorBox. <br/>
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task<TorBoxResponse<TorrentCheckCachedResponse?>> GetCheckCached(TorrentCheckCachedRequest request, CancellationToken cancellationToken);
}
