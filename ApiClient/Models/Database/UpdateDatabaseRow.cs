using System.Text.Json.Serialization;

namespace ApiClient.Models.Database;

public class UpdateDatabaseRow<T>
{
    [JsonPropertyName("pre_hash")]
    public string PreHash { get; set; }
    [JsonPropertyName("cells")]
    public T Cells { get; set; }
    [JsonPropertyName("doc")]
    public string Doc { get; set; }
}