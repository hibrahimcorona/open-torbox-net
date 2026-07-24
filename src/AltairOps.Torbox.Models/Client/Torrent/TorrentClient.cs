using AltairOps.Torbox.Models.Constants;
using AltairOps.Torbox.Models.Requests;
using AltairOps.Torbox.Models.Requests.Torrents;
using AltairOps.Torbox.Models.Responses;
using AltairOps.Torbox.Models.Responses.Torrents;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
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
	/// Initializes a new instance of the <see cref="TorBoxConfiguration"/>.
	/// </summary>
	private readonly TorBoxConfiguration _configuration;

	/// <summary>
	/// Initializes a new instance of the <see cref="TorrentClient"/> class.
	/// </summary>
	/// <param name="httpClient"></param>
	public TorrentClient(HttpClient httpClient, TorBoxConfiguration configuration)
	{
		_configuration = configuration;
		_httpClient = httpClient ?? new HttpClient();
		_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration.BearerToken);
	}

	public async Task<TorBoxResponse<List<TorrentListResponse?>>> ListTorrents(TorrentListRequest request, CancellationToken cancellationToken = default)
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

		var buffer = await httpResponse.Content.ReadAsByteArrayAsync();
		var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

		return await httpResponse.Content.ReadFromJsonAsync<TorBoxResponse<List<TorrentListResponse?>>>();
	}

	public async Task<TorBoxResponse<TorrentAddResponse?>> AddTorrent(TorrentAddRequest request, CancellationToken cancellationToken = default)
	{
		var dataContent = new MultipartFormDataContent();
		dataContent.AddIfHasValue("file", request.File);
		dataContent.AddIfHasValue("magnet", request.Magnet);
		dataContent.AddIfHasValue("seed", request.Seed);
		dataContent.AddIfHasValue("allow_zip", request.AllowZip);
		dataContent.AddIfHasValue("name", request.Name);
		dataContent.AddIfHasValue("as_queued", request.AsQueued);
		dataContent.AddIfHasValue("add_only_if_cached", request.AddOnlyIfCached);

		var httpResponse = await _httpClient.PostAsync($"{Endpoints.AddTorrent}", dataContent);
		if (httpResponse == null)
		{
			return null;
		}

		var buffer = await httpResponse.Content.ReadAsByteArrayAsync();
		var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

		return await httpResponse.Content.ReadFromJsonAsync<TorBoxResponse<TorrentAddResponse?>>();
	}
}
