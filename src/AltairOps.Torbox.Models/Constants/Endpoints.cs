namespace AltairOps.Torbox.Models.Constants;

public class Endpoints
{
	public static string ListTorrents => "torrents/mylist";

	public static string AddTorrent => "torrents/createtorrent";

	public static string AddTorrentAsync => "torrents/asynccreatetorrent";

	public static string DownloadRequest => "torrents/requestdl";

	public static string ControlTorrent = "torrents/controltorrent";

	public static string CheckCached = "torrents/checkcached";

	public static string CheckCachedByBatch = "torrents/checkcached";
}
