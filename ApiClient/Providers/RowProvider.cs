using System.Text.Json;
using ApiClient.Models;
using ApiClient.Models.Database;
using ApiClient.Models.Database.Rows;
using ApiClient.Providers.Interfaces;

namespace ApiClient.Providers;

internal class RowProvider(string url, string token) : Provider(url, token), IRowProvider
{
    public async Task<List<DatabaseRowId>> GetRowsIdAsync(string workspaceId, string databaseId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row");
        var rows = await deserialization.Deserialize<DatabaseRowId[]>(response);
        return rows.ToList();
    }
    
    public async Task<List<DatabaseRowId>> GetUpdatedRowsIdAsync(string workspaceId, string databaseId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row/updated");
        var rows = await deserialization.Deserialize<DatabaseRowId[]>(response);
        return rows.ToList();
    }

    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public async Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId, List<DatabaseRowId> rowIds)
    {
        var rowsIdsString = rowIds.Select(rowId => rowId.Id).ToList();
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var ids = string.Join(",", rowsIdsString);
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row/detail?ids={ids}");
        var rows = await deserialization.Deserialize<DatabaseRow<T>[]>(response);
        return rows.ToList();
    }
    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public async Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId, DatabaseRowId rowId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var ids = rowId.Id;
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row/detail?ids={ids}");
        var rows = await deserialization.Deserialize<DatabaseRow<T>[]>(response);
        return rows.ToList();
    }
    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public async Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId, string rowId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row/detail?ids={rowId}");
        var rows = await deserialization.Deserialize<DatabaseRow<T>[]>(response);
        return rows.ToList();
    }

    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (Cells) in appflowy.</typeparam>
    public async Task<string> CreateAsync<T>(string workspaceId, string databaseId, CreateDatabaseRow<T> data)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri($"{url}api/workspace/{workspaceId}/database/{databaseId}/row/"),
            Method = HttpMethod.Post,
            Content = new StringContent(JsonSerializer.Serialize(data), System.Text.Encoding.UTF8, "application/json")
        };
        var response = await client.SendAsync(requestMessage);
        return await deserialization.Deserialize<string>(response);
    }
}