using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Responses.Torrents;

public class TorrentListResponse
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("auth_id")]
	public string AuthId { get; set; }

	[JsonPropertyName("server")]
	public int Server { get; set; }

	[JsonPropertyName("hash")]
	public string Hash { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("magnet")]
	public string Magnet { get; set; }

	[JsonPropertyName("size")]
	public int Size { get; set; }

	[JsonPropertyName("active")]
	public bool Active { get; set; }

	[JsonPropertyName("created_at")]
	public DateTime Created_at { get; set; }

	[JsonPropertyName("updated_at")]
	public DateTime Updated_at { get; set; }

	[JsonPropertyName("download_state")]
	public string DownloadState { get; set; }

	[JsonPropertyName("seeds")]
	public int Seeds { get; set; }

	[JsonPropertyName("peers")]
	public int Peers { get; set; }

	[JsonPropertyName("ratio")]
	public int Ratio { get; set; }

	[JsonPropertyName("progress")]
	public int Progress { get; set; }

	[JsonPropertyName("download_speed")]
	public int DownloadSpeed { get; set; }

	[JsonPropertyName("upload_speed")]
	public int UploadSpeed { get; set; }

	[JsonPropertyName("eta")]
	public int Eta { get; set; }

	[JsonPropertyName("torrent_file")]
	public bool Torrent_file { get; set; }

	[JsonPropertyName("expires_at")]
	public DateTime Expires_at { get; set; }

	[JsonPropertyName("download_present")]
	public bool DownloadPresent { get; set; }

	[JsonPropertyName("files")]
	public TorrentFile[] Files { get; set; }

	[JsonPropertyName("download_path")]
	public string DownloadPath { get; set; }

	[JsonPropertyName("availability")]
	public int Availability { get; set; }

	[JsonPropertyName("download_finished")]
	public bool DownloadFinished { get; set; }

	[JsonPropertyName("tracker")]
	public string Tracker { get; set; }

	[JsonPropertyName("total_uploaded")]
	public int TotalIploaded { get; set; }

	[JsonPropertyName("total_downloaded")]
	public int TotalDownloaded { get; set; }

	[JsonPropertyName("cached")]
	public bool Cached { get; set; }

	[JsonPropertyName("owner")]
	public string Owner { get; set; }

	[JsonPropertyName("seed_torrent")]
	public bool SeedTorrent { get; set; }

	[JsonPropertyName("allow_zipped")]
	public bool AllowZipped { get; set; }

	[JsonPropertyName("long_term_seeding")]
	public bool LongTermSeeding { get; set; }

	[JsonPropertyName("tracker_message")]
	public string TrackerMessage { get; set; }

	[JsonPropertyName("cached_at")]
	public DateTime CachedAt { get; set; }

	[JsonPropertyName("private")]
	public bool Private { get; set; }

	[JsonPropertyName("alternative_hashes")]
	public string[] AlternativeHashes { get; set; }

	[JsonPropertyName("tags")]
	public string[] Tags { get; set; }

	[JsonPropertyName("air_locked")]
	public bool AirLocked { get; set; }
}

public class TorrentFile
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("md5")]
	public string Md5 { get; set; }

	[JsonPropertyName("hash")]
	public string Hash { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("size")]
	public int Size { get; set; }

	[JsonPropertyName("zipped")]
	public bool Zipped { get; set; }

	[JsonPropertyName("s3_path")]
	public string S3Path { get; set; }

	[JsonPropertyName("infected")]
	public bool Infected { get; set; }

	[JsonPropertyName("mimetype")]
	public string Mimetype { get; set; }

	[JsonPropertyName("short_name")]
	public string ShortName { get; set; }

	[JsonPropertyName("absolute_path")]
	public string AbsolutePath { get; set; }

	[JsonPropertyName("opensubtitles_hash")]
	public string OpensubtitlesHash { get; set; }
}

