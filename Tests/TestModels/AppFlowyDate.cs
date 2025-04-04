using System.Text.Json.Serialization;

namespace Tests.TestModels;

public class AppFlowyDate
{
    [JsonPropertyName("end")]
    public string End { get; set; }
    [JsonPropertyName("start")]
    public string Start { get; set; }
    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }
    [JsonPropertyName("pretty_end_datetime")]
    public string PrettyEndDateTime { get; set; }
    [JsonPropertyName("pretty_start_datetime")]
    public string PrettyStartDateTime { get; set; }
    [JsonPropertyName("pretty_end_date")]
    public string PrettyEndDate { get; set; }
    [JsonPropertyName("pretty_start_date")]
    public string PrettyStartDate { get; set; }
    [JsonPropertyName("pretty_end_time")]
    public string PrettyEndTime { get; set; }
    [JsonPropertyName("pretty_start_time")]
    public string PrettyStartTime { get; set; }
    
}