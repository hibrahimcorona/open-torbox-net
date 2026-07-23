using AltairOps.Torbox.Models.Client;
using AltairOps.Torbox.Models.Responses.Torrents;
using Microsoft.AspNetCore.Mvc;
using AltairOps.Torbox.Models.Constants;
using AltairOps.Torbox.Models.Requests;

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
			var torrents = await _torBoxClient.TorrentClient.GetAsync(request);
			return Ok(torrents);
		}
	}
}
