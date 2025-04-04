using System.Text.Json.Serialization;

namespace Tests.TestModels;

public class ToDo
{
    [JsonPropertyName("options")]
    public ToDoOptions[] Options { get; set; }
    [JsonPropertyName("selected_option_ids")]
    public string[] SelectedOptionsIds { get; set; }
}