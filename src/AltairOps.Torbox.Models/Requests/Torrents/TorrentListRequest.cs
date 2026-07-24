using Microsoft.AspNetCore.Mvc;

namespace AltairOps.Torbox.Models.Requests.Torrents;

public class TorrentListRequest
{
	[FromQuery(Name = "bypass_cache")]
	public bool BypassCache { get; set; } = false;

	[FromQuery(Name = "id")]
	public int? Id { get; set; }

	[FromQuery(Name = "offset")]
	public int Offset { get; set; } = 0;

	[FromQuery(Name = "limit")]
	public int Limit { get; set; } = 10;
}
