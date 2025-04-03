using System.Text.Json.Serialization;

namespace ApiClient.Models.Workspace;

public class WorkspaceFolder
{
    [JsonPropertyName("view_id")]
    public string ViewId { get; set; }

    [JsonPropertyName("parent_view_id")]
    public string ParentViewId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("is_space")]
    public bool IsSpace { get; set; }

    [JsonPropertyName("is_private")]
    public bool IsPrivate { get; set; }

    [JsonPropertyName("is_published")]
    public bool IsPublished { get; set; }

    [JsonPropertyName("is_favorite")]
    public bool IsFavorite { get; set; }

    [JsonPropertyName("layout")]
    public int Layout { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("created_by")]
    public ulong CreatedBy { get; set; }

    [JsonPropertyName("last_edited_by")]
    public ulong LastEditedBy { get; set; }

    [JsonPropertyName("last_edited_time")]
    public DateTime LastEditedTime { get; set; }

    [JsonPropertyName("is_locked")]
    public bool? IsLocked { get; set; }

    [JsonPropertyName("extra")]
    public Extra Extra { get; set; }

    [JsonPropertyName("children")]
    public WorkspaceFolder[] Children { get; set; }
    
}

