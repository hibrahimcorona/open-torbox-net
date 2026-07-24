using System.Text.Json.Serialization;

namespace AltairOps.Torbox.Models.Responses;

public class TorBoxResponse<T> : TorBoxBaseResponse
{
	[JsonPropertyName("data")]
	public T? Data { get; set; }
}
