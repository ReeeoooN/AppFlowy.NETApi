using System.Text.Json.Serialization;

namespace ApiClient.Models.Workspace;

public class Workspace
{
    [JsonPropertyName("workspace_id")]
    public string WorkspaceId { get; set; }
    [JsonPropertyName("database_storage_id")]
    public string DatabaseStroageId { get; set; }
    [JsonPropertyName("owner_uid")]
    public ulong OwnerUid { get; set; }
    [JsonPropertyName("owner_name")]
    public string OwnerName { get; set; }
    [JsonPropertyName("owner_email")]
    public string OwnerEmail { get; set; }
    [JsonPropertyName("workspace_type")]
    public int WorkspaseType { get; set; }
    [JsonPropertyName("workspace_name")]
    public string WorkspaceName { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    public string Icon  { get; set; }
    [JsonPropertyName("member_count")]
    public ulong? MemberCount { get; set; }
}