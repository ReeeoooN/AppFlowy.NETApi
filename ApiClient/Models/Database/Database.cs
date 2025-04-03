using System.Text.Json.Serialization;

namespace ApiClient.Models.Database;

public class Database
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("views")]
    public DatabaseView[] Views { get; set; }
}