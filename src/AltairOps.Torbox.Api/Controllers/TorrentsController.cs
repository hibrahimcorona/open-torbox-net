using AltairOps.Torbox.Models.Client;
using AltairOps.Torbox.Models.Requests.Torrents;
using Microsoft.AspNetCore.Mvc;

namespace AltairOps.Torbox.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TorrentsController : ControllerBase
	{
		private TorBoxClient _torBoxClient;

		public TorrentsController(TorBoxClient torBoxClient)
		{
			_torBoxClient = torBoxClient;
		}

		[HttpGet("list")]
		public async Task<IActionResult> ListTorrents([FromQuery] TorrentListRequest request, CancellationToken cancellationToken = default)
		{
			var torrentList = await _torBoxClient.TorrentClient.GetListTorrents(request, cancellationToken);
			return Ok(torrentList);
		}

		[HttpPost("add-torrent")]
		public async Task<IActionResult> ListTorrents([FromQuery] TorrentAddRequest request, CancellationToken cancellationToken = default)
		{
			var torrentCreation = await _torBoxClient.TorrentClient.PostAddTorrent(request, cancellationToken);
			return Ok(torrentCreation);
		}

		[HttpGet("download-link")]
		public async Task<IActionResult> DownloadLink([FromQuery] TorrentRequestDownloadRequest request, CancellationToken cancellationToken = default)
		{
			var torrentDownloadLink = await _torBoxClient.TorrentClient.GetDownloadLink(request, cancellationToken);
			return Ok(torrentDownloadLink);
		}

		[HttpPost("control-torrent")]
		public async Task<IActionResult> ControlTorrent([FromQuery] TorrentControlRequest request, CancellationToken cancellationToken = default)
		{
			var controlResponse = await _torBoxClient.TorrentClient.PostControlTorrent(request, cancellationToken);
			return Ok(controlResponse);
		}

		[HttpGet("check-cached")]
		public async Task<IActionResult> CheckCached([FromQuery] TorrentCheckCachedRequest request, CancellationToken cancellationToken = default)
		{
			var cachedResponse = await _torBoxClient.TorrentClient.GetCheckCached(request, cancellationToken);
			return Ok(cachedResponse);
		}
	}
}
