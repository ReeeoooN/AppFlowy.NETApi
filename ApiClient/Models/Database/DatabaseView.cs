using System.Text.Json.Serialization;

namespace ApiClient.Models.Database;

public class DatabaseView
{
    [JsonPropertyName("view_id")]
    public string ViewId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("icon")]
    public ViewIcon Icon { get; set; }
    [JsonPropertyName("layout")]
    public int Layout { get; set; }
}