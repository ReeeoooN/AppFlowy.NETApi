using System.Text.Json.Serialization;

namespace ApiClient.Models.Database;

public class DatabaseRowId
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
}