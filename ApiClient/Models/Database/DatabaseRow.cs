using System.Text.Json.Serialization;
namespace ApiClient.Models.Database.Rows;
/// <summary>
/// The "T" parameter is your class that describes the model for custom fields in appflowy.
/// </summary>
public class DatabaseRow<T>
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("cells")]
    public T Cells { get; set; }
    [JsonPropertyName("has_doc")]
    public bool HasDoc { get; set; }
    [JsonPropertyName("doc")]
    public string Doc { get; set; }
}