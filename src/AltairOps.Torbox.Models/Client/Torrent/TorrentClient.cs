using AltairOps.Torbox.Models.Constants;
using AltairOps.Torbox.Models.Requests;
using AltairOps.Torbox.Models.Responses.Torrents;
using System.Net.Http.Json;
using System.Web;

namespace AltairOps.Torbox.Models.Client.Torrent;

/// <summary>
/// Represents a client for interacting with torrent-related operations.
/// </summary>
public class TorrentClient : ITorrentClient
{
	/// <summary>
	/// The HTTP client used for making requests to the torrent API.
	/// </summary>
	private readonly HttpClient _httpClient;

	/// <summary>
	/// Initializes a new instance of the <see cref="TorrentClient"/> class.
	/// </summary>
	/// <param name="httpClient"></param>
	public TorrentClient(HttpClient httpClient, TorBoxConfiguration config)
	{
		_httpClient = httpClient ?? new HttpClient();
	}

	public async Task<List<TorrentListResponse>> GetAsync(TorrentListRequest request)
	{
		var parameters = HttpUtility.ParseQueryString(string.Empty);
		parameters["bypass_cache"] = request.BypassCache.ToString().ToLower();
		parameters["limit"] = request.Limit.ToString();
		parameters["offset"] = request.Offset.ToString();

		var httpResponse = await _httpClient.GetAsync($"{Endpoints.ListTorrents}?{parameters}");
		if (httpResponse == null) 
		{
			return null;
		}

		var parsedResponse = await httpResponse.Content.ReadFromJsonAsync<List<TorrentListResponse>>();
		return parsedResponse;
	}
}
