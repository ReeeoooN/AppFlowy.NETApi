using ApiClient.Models;
using ApiClient.Models.Database;
using ApiClient.Models.Database.Rows;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ApiClient.Providers;

public class DatabaseProvider(string url, string accessToken)
{
    public RowProvider Rows = new(url, accessToken);
    public async Task<List<Database>> GetAsync( string workspaceId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var DTO = JsonSerializer.Deserialize<ResponseObjectArray<Database>>(result);
            if (DTO.code == 0)
            {
                if (DTO.data is not null || DTO.data.Length != 0)
                {
                    return DTO.data.ToList();
                }
                throw new NullReferenceException("Content was null");
            }
            throw new HttpRequestException($"An error occured while getting content (code {DTO.code}), message: {DTO.message}");
        }
        throw new HttpRequestException($"Error getting content: {await response.Content.ReadAsStringAsync()}");
    }

    
}