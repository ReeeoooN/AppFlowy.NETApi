using ApiClient.Models;
using ApiClient.Models.Database;
using ApiClient.Models.Database.Rows;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Providers;

public class DatabaseProvider(string url, string token) : Provider(url, token)
{
    public RowProvider Rows = new(url, token);
    public async Task<List<Database>> GetAsync( string workspaceId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database");
        var databases = await deserialization.Deserialize<Database[]>(response);
        return databases.ToList();
    }

    
}