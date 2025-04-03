using System.Text.Json.Serialization;

namespace ApiClient.Models.Workspace;

public class Extra
{
    [JsonPropertyName("is_space")]
    public bool IsSpace { get; set; }

    [JsonPropertyName("space_created_at")]
    public long SpaceCreatedAt { get; set; }

    [JsonPropertyName("space_icon")]
    public string SpaceIcon { get; set; }

    [JsonPropertyName("space_icon_color")]
    public string SpaceIconColor { get; set; }

    [JsonPropertyName("space_permission")]
    public int SpacePermission { get; set; }
}