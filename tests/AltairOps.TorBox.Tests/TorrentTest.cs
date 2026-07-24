using AltairOps.Torbox.Models.Client;
using AltairOps.Torbox.Models.Requests.Torrents;
using NUnit.Framework;

namespace AltairOps.TorBox.Tests;

[TestFixture]
public class TorrentTest
{
	private TorBoxClient _torBoxClient;
	private TorBoxConfiguration _torBoxConfiguration;

	[SetUp]
	public void Setup()
	{
		_torBoxConfiguration = new TorBoxConfiguration("c:\\temp\\");
		_torBoxClient = new TorBoxClient(new HttpClient(), _torBoxConfiguration);
	}

	[Test]
	public async Task TestListTorrents()
	{
		var request = new TorrentListRequest();
		var response = await _torBoxClient.TorrentClient.GetListTorrents(request);
		Assert.IsNotNull(response);
	}

	[Test]
	public async Task TestAddTorrent()
	{
		var request = new TorrentAddRequest
		{
			Magnet = "magnet:?xt=urn:btih:9EE38ECC0105ED61B0EF93A875325AFE784B6FB5&dn=Big.Buck.Bunny.1080p.Surround&tr=udp%3A%2F%2Ftracker.opentrackr.org%3A1337&tr=udp%3A%2F%2Fopen.stealth.si%3A80%2Fannounce&tr=udp%3A%2F%2Ftracker.torrent.eu.org%3A451%2Fannounce&tr=udp%3A%2F%2Ftracker.bittor.pw%3A1337%2Fannounce&tr=udp%3A%2F%2Fpublic.popcorn-tracker.org%3A6969%2Fannounce&tr=udp%3A%2F%2Ftracker.dler.org%3A6969%2Fannounce&tr=udp%3A%2F%2Fexodus.desync.com%3A6969&tr=udp%3A%2F%2Fopen.demonii.com%3A1337%2Fannounce&tr=udp%3A%2F%2Fglotorrents.pw%3A6969%2Fannounce&tr=udp%3A%2F%2Ftracker.coppersurfer.tk%3A6969&tr=udp%3A%2F%2Ftorrent.gresille.org%3A80%2Fannounce&tr=udp%3A%2F%2Fp4p.arenabg.com%3A1337&tr=udp%3A%2F%2Ftracker.internetwarriors.net%3A1337",
		};
		var response = await _torBoxClient.TorrentClient.PostAddTorrent(request);
		Assert.IsNotNull(response);
	}

}
