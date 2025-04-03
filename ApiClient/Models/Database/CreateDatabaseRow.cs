using System.Text.Json.Serialization;

namespace ApiClient.Models.Database;

public class CreateDatabaseRow <T>
{
    [JsonPropertyName("cells")]
    public T Cells { get; set; }
    [JsonPropertyName("doc")]
    public string Doc { get; set; }
}