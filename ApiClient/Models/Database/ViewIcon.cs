using System.Text.Json.Serialization;

namespace ApiClient.Models.Database;

public class ViewIcon
{
    [JsonPropertyName("ty")]
    public int Type { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
}