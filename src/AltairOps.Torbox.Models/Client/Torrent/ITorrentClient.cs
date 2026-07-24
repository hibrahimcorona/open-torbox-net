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
	public Task<TorBoxResponse<List<TorrentListResponse?>>> ListTorrents(TorrentListRequest request, CancellationToken cancellationToken = default);

	/// <summary>
	/// Adds a torrent to your TorBox account.
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task<TorBoxResponse<TorrentAddResponse?>> AddTorrent(TorrentAddRequest request, CancellationToken cancellationToken = default);

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
	/// Reannounce reannounces the torrent to get new peers.
	/// Delete deletes the torrent from the client and your account permanently
	/// Resume resumes a paused torrent
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public Task<TorBoxResponse<ControlTorrentResponse?>> ControlTorrent (TorrentControlRequest request, CancellationToken cancellationToken = default);
}
