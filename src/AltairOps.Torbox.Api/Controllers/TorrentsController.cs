using AltairOps.Torbox.Models.Requests;
using AltairOps.Torbox.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace AltairOps.Torbox.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TorrentsController : ControllerBase
	{
		private readonly TorboxService _torBoxService;

		public TorrentsController(TorboxService torBoxService) => _torBoxService = torBoxService;

		[HttpPost("add")]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> AddTorrent([FromForm] CreateTorrentRequest request, CancellationToken cancellationToken = default)
		{
			if (request.Magnet is null)
			{
				return BadRequest("You must provide a magnet or .torrent file");
			}

			var result = await _torBoxService.CreateTorrentAsync(request, cancellationToken);

			return Ok(result);
		}

		[HttpGet("list")]
		public async Task<IActionResult> ListTorrents([FromQuery] TorrentListRequest request, CancellationToken cancellationToken = default)
		{
			var result = await _torBoxService.TorrentListAsync(request, cancellationToken);
			return Ok(result);
		}

		[HttpGet("check-cached")]
		public async Task<IActionResult> CheckCached([FromQuery] CheckCachedRequest request, CancellationToken cancellationToken = default)
		{
			var result = await _torBoxService.CheckCachedAsync(request, cancellationToken);
			return Ok(result);
		}

		[HttpGet("request-download")]
		public async Task<IActionResult> RequestDownload([FromQuery] DownloadLinkRequest request, CancellationToken cancellationToken = default)
		{
			var result = await _torBoxService.RequestDownloadAsync(request, cancellationToken);
			return Ok(result);
		}
	}
}
