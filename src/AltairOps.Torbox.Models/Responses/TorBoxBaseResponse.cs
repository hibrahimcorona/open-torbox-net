using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Responses;

/// <summary>
/// Base response from TorBox.
/// </summary>
public class TorBoxBaseResponse
{
	[JsonPropertyName("success")]
	public bool Success { get; set; }

	[JsonPropertyName("error")]
	public string? Error { get; set; }

	[JsonPropertyName("detail")]
	public string Detail { get; set; } = string.Empty;
}