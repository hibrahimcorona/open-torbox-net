using AltairOps.Torbox.Models.Helpers;
using System.Text.Json;

namespace AltairOps.Torbox.Models;

/// <summary>
/// Represents the setup configuration for the application, including secrets and other settings.
/// </summary>
public class Setup
{
	/// <summary>
	/// The name of the secrets file used for configuration.
	/// </summary>
	private const string _secretsFileName = "secrets.json";

	public static string ApiKey
	{
		get { return _secretsFileName; }
	}

	public static Secrets LoadSecrets(string path)
	{
		var fullPath = Path.Combine(path, _secretsFileName);
		if (!File.Exists(fullPath))
		{
			throw new FileNotFoundException($"The secrets file '{_secretsFileName}' was not found.");
		}

		var secretsContent = File.ReadAllText(fullPath);
		return JsonSerializer.Deserialize<Secrets>(secretsContent);
	}
}
