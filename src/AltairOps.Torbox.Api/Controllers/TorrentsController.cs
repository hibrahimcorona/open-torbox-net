using AltairOps.Torbox.Models.Client;
using AltairOps.Torbox.Models.Responses.Torrents;
using Microsoft.AspNetCore.Mvc;
using AltairOps.Torbox.Models.Constants;
using AltairOps.Torbox.Models.Requests;
using AltairOps.Torbox.Models.Requests.Torrents;

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
		public async Task<IActionResult> ListTorrents([FromQuery] TorrentListRequest request)
		{
			var torrentList = await _torBoxClient.TorrentClient.ListTorrents(request);
			return Ok(torrentList);
		}

		[HttpPost("add-torrent")]
		public async Task<IActionResult> ListTorrents([FromQuery] TorrentAddRequest request)
		{
			var torrentCreation = await _torBoxClient.TorrentClient.AddTorrent(request);
			return Ok(torrentCreation);
		}

		[HttpGet("download-link")]
		public async Task<IActionResult> DownloadLink([FromQuery] TorrentRequestDownloadRequest request)
		{
			var torrentDownloadLink = await _torBoxClient.TorrentClient.GetDownloadLink(request);
			return Ok(torrentDownloadLink);
		}
	}
}
