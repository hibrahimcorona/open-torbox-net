/// <summary>
/// Manages the types of operations that you can do to control torrents.
/// </summary>
public enum ControlTorrentOperation
{
	/// <summary>
	/// Reannounces the torrent to get new peers.
	/// </summary>
	Reannounce,
	/// <summary>
	/// Deletes the torrent from the client and your account permanently.
	/// </summary>
	Delete,
	/// <summary>
	/// Resumes a paused torrent.
	/// </summary>
	Resume
}