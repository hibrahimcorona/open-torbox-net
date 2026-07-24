using Microsoft.Extensions.Configuration;

namespace AltairOps.Torbox.Models.Client;

public class TorBoxConfiguration
{
	private IConfiguration _configuration;

	/// <summary>
	/// The base URL for the TorBox API.
	/// </summary>
	public string BaseUrl { get; set; } = "https://api.torbox.app/v1/api/";

	/// <summary>
	/// The configuration object used to retrieve settings from the secrets.json file.
	/// </summary>
	private string? ApiKey { get; set; } = string.Empty;

	/// <summary>
	/// Gets the bearer token for authentication with the TorBox API.
	/// </summary>
	public string? BearerToken
	{
		get
		{
			if (string.IsNullOrEmpty(ApiKey))
			{
				throw new InvalidOperationException("API key is not set. Please set the API key before making requests.");
			}

			return $"{ApiKey}";
		}
	}

	public TorBoxConfiguration(string secretsPath)
	{
		if (secretsPath is null)
		{
			return;
		}

		var secrets = Setup.LoadSecrets(secretsPath);
		ApiKey = secrets.ApiKey;
	}

	public TorBoxConfiguration(IConfiguration configuration)
	{
		_configuration = configuration;
		LoadConfiguration();
	}

	private void LoadConfiguration()
	{
		var secretsPath = _configuration["Secrets:Path"];
		if (string.IsNullOrWhiteSpace(secretsPath))
		{
			return;
		}

		var secrets = Setup.LoadSecrets(secretsPath);
		ApiKey = secrets.ApiKey;
	}
}
