using AltairOps.Torbox.Models.Constants;
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

	public async Task<TorBoxResponse<List<TorrentListResponse?>>> GetListTorrents(TorrentListRequest request, CancellationToken cancellationToken = default)
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

	public async Task<TorBoxResponse<TorrentAddResponse?>> PostAddTorrent(TorrentAddRequest request, CancellationToken cancellationToken = default)
	{
		var dataContent = new MultipartFormDataContent();
		dataContent.AddIfHasValue("file", request.File);
		dataContent.AddIfHasValue("magnet", request.Magnet);
		dataContent.AddIfHasValue("seed", request.Seed);
		dataContent.AddIfHasValue("allow_zip", request.AllowZip);
		dataContent.AddIfHasValue("name", request.Name);
		dataContent.AddIfHasValue("as_queued", request.AsQueued);
		dataContent.AddIfHasValue("add_only_if_cached", request.AddOnlyIfCached);

		var httpResponse = await _httpClient.PostAsync(request.AddAsync ? $"{Endpoints.AddTorrentAsync}" : $"{Endpoints.AddTorrent}", dataContent);
		if (httpResponse == null)
		{
			return null;
		}

		var buffer = await httpResponse.Content.ReadAsByteArrayAsync();
		var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

		return await httpResponse.Content.ReadFromJsonAsync<TorBoxResponse<TorrentAddResponse?>>();
	}

	public async Task<TorBoxResponse<string?>> GetDownloadLink(TorrentRequestDownloadRequest request, CancellationToken cancellationToken = default)
	{
		var parameters = HttpUtility.ParseQueryString(string.Empty);
		parameters["token"] = _configuration.BearerToken;
		parameters.AddIfHasValue("torrent_id", request.TorrentId);
		parameters.AddIfHasValue("file_id", request.FileId);
		parameters.AddIfHasValue("zip_link", request.ZipLink);
		parameters.AddIfHasValue("user_ip", request.UserIp);
		parameters.AddIfHasValue("redirect", request.Redirect);
		parameters.AddIfHasValue("append_name", request.AppendName);

		var httpResponse = await _httpClient.GetAsync($"{Endpoints.DownloadRequest}?{parameters}");
		if (httpResponse == null)
		{
			return null;
		}

		var buffer = await httpResponse.Content.ReadAsByteArrayAsync();
		var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

		return await httpResponse.Content.ReadFromJsonAsync<TorBoxResponse<string>>();
	}

	public async Task<TorBoxResponse<ControlTorrentResponse?>> PostControlTorrent(TorrentControlRequest request, CancellationToken cancellationToken)
	{
		var data = new Dictionary<string, string>
		{
			{ "torrent_id", request.TorrentId?.ToString() ?? string.Empty },
			{ "operation", request.ControlTorrentOperation.ToString().ToLowerInvariant() },
			{ "all", request.All.ToString().ToLower() }
		};

		var httpResponse = await _httpClient.PostAsJsonAsync($"{Endpoints.ControlTorrent}", data);
		if (httpResponse == null)
		{
			return null;
		}

		var buffer = await httpResponse.Content.ReadAsByteArrayAsync();
		var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

		return await httpResponse.Content.ReadFromJsonAsync<TorBoxResponse<ControlTorrentResponse?>>();
	}

	public async Task<TorBoxResponse<TorrentCheckCachedResponse?>> GetCheckCached(TorrentCheckCachedRequest request, CancellationToken cancellationToken)
	{
		var parameters = HttpUtility.ParseQueryString(string.Empty);
		parameters.AddIfHasValue("hash", request.Hash);
		parameters.AddIfHasValue("format", request.Format);
		parameters.AddIfHasValue("list_files", request.ListFiles.ToString().ToLower());

		var httpResponse = await _httpClient.GetAsync($"{Endpoints.CheckCached}?{parameters}");
		if (httpResponse == null)
		{
			return null;
		}

		var buffer = await httpResponse.Content.ReadAsByteArrayAsync();
		var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

		return await httpResponse.Content.ReadFromJsonAsync<TorBoxResponse<TorrentCheckCachedResponse?>>();
	}
}
