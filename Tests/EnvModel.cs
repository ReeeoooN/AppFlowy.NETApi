using System.Text.Json.Serialization;

namespace Tests;

public class EnvModel
{
    [JsonPropertyName("url")] 
    public string Url { get; set; }
    [JsonPropertyName("token")]
    public string Token { get; set; }
    [JsonPropertyName("workspace")]
    public string Wokspace { get; set; }
    [JsonPropertyName("database")]
    public string Database { get; set; }
    [JsonPropertyName("row")]
    public string Row { get; set; }
}