using System.Text.Json.Serialization;

namespace Tests.TestModels;

public class TestCells
{
    [JsonPropertyName("Приоритет")]
    public string Priority { get; set; }
    [JsonPropertyName("Подробнее")]
    public string Description { get; set; }
    [JsonPropertyName("Ответственный")]
    public string[] Responses { get; set; }
    [JsonPropertyName("Description")]
    public string Name { get; set; }
    [JsonPropertyName("Status")]
    public string Status { get; set; }
    [JsonPropertyName("To-Do лист")]
    public ToDo ToDo { get; set; }
    [JsonPropertyName("Дата")]
    public AppFlowyDate Date { get; set; }
}