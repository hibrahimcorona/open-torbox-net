using System.Net.Http.Headers;
using AltairOps.Torbox.Models.Client.Torrent;

namespace AltairOps.Torbox.Models.Client;

/// <summary>
/// Represents a client for calling the TorBox API.
/// </summary>
public class TorBoxClient
{
	/// <summary>
	/// The HTTP client used for making requests to the TorBox API.
	/// </summary>
	private readonly HttpClient _torBoxHttpClient;

	/// <summary>
	/// Initializes a new instance of the <see cref="TorBoxConfiguration"/>.
	/// </summary>
	private readonly TorBoxConfiguration _config;

	/// <summary>
	/// Gets the torrent client for interacting with torrent-related operations.
	/// </summary>
	public ITorrentClient TorrentClient { get; }

	public TorBoxClient(HttpClient torBoxHttpClient, TorBoxConfiguration config)
	{
		_config = config;
		_torBoxHttpClient = torBoxHttpClient;

		_torBoxHttpClient.BaseAddress = new Uri(_config.BaseUrl);
		_torBoxHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config.BearerToken);
		TorrentClient = new TorrentClient(_torBoxHttpClient, config);
	}
}