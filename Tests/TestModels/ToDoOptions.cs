using System.Text.Json.Serialization;

namespace Tests.TestModels;

public class ToDoOptions
{
    [JsonPropertyName("color")]
    public string Color { get; set; }
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
}