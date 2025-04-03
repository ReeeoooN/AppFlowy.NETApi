using System.Text.Json;
using ApiClient.Models;
using ApiClient.Models.Database;
using ApiClient.Models.Database.Rows;

namespace ApiClient.Providers;

public class RowProvider(string url, string accessToken)
{
    public async Task<List<DatabaseRowId>> GetRowsIdAsync(string workspaceId, string databaseId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var DTO = JsonSerializer.Deserialize<ResponseObjectArray<DatabaseRowId>>(result);
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
    
    public async Task<List<DatabaseRowId>> GetUpdatedRowsIdAsync(string workspaceId, string databaseId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row/updated");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var DTO = JsonSerializer.Deserialize<ResponseObjectArray<DatabaseRowId>>(result);
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

    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public async Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId, List<DatabaseRowId> rowIds)
    {
        var rowsIdsString = rowIds.Select(rowId => rowId.Id).ToList();
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        var ids = string.Join(",", rowsIdsString);
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row/detail?ids={ids}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                var DTO = JsonSerializer.Deserialize<ResponseObjectArray<DatabaseRow<T>>>(result);
                if (DTO.code == 0)
                {
                    if (DTO.data is not null || DTO.data.Length != 0)
                    {
                        return DTO.data.ToList();
                    }

                    throw new NullReferenceException("Content was null");
                }
                throw new HttpRequestException(
                    $"An error occured while getting content (code {DTO.code}), message: {DTO.message}");
            }
            catch (JsonException e)
            {
                throw new JsonException("An error occured while getting content from JSON", e);
            }
        }
        throw new HttpRequestException($"Error getting content: {await response.Content.ReadAsStringAsync()}");
    }
    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public async Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId, DatabaseRowId rowId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        var ids = rowId.Id;
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row/detail?ids={ids}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                var DTO = JsonSerializer.Deserialize<ResponseObjectArray<DatabaseRow<T>>>(result);
                if (DTO.code == 0)
                {
                    if (DTO.data is not null || DTO.data.Length != 0)
                    {
                        return DTO.data.ToList();
                    }

                    throw new NullReferenceException("Content was null");
                }
                throw new HttpRequestException(
                    $"An error occured while getting content (code {DTO.code}), message: {DTO.message}");
            }
            catch (JsonException e)
            {
                throw new JsonException("An error occured while getting content from JSON", e);
            }
        }
        throw new HttpRequestException($"Error getting content: {await response.Content.ReadAsStringAsync()}");
    }
    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public async Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId, string rowId)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        var response = await client.GetAsync($"api/workspace/{workspaceId}/database/{databaseId}/row/detail?ids={rowId}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                var DTO = JsonSerializer.Deserialize<ResponseObjectArray<DatabaseRow<T>>>(result);
                if (DTO.code == 0)
                {
                    if (DTO.data is not null || DTO.data.Length != 0)
                    {
                        return DTO.data.ToList();
                    }

                    throw new NullReferenceException("Content was null");
                }
                throw new HttpRequestException(
                    $"An error occured while getting content (code {DTO.code}), message: {DTO.message}");
            }
            catch (JsonException e)
            {
                throw new JsonException("An error occured while getting content from JSON", e);
            }
        }
        throw new HttpRequestException($"Error getting content: {await response.Content.ReadAsStringAsync()}");
    }

    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (Cells) in appflowy.</typeparam>
    public async Task<string> CreateAsync<T>(string workspaceId, string databaseId, CreateDatabaseRow<T> data)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(url);
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri($"{url}api/workspace/{workspaceId}/database/{databaseId}/row/"),
            Method = HttpMethod.Post,
            Content = new StringContent(JsonSerializer.Serialize(data), System.Text.Encoding.UTF8, "application/json")
        };
        var response = await client.SendAsync(requestMessage);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            try
            {
                var DTO = JsonSerializer.Deserialize<ResponseObject<string>>(result);
                if (DTO.code == 0)
                {
                    if (DTO.data is not null)
                    {
                        return DTO.data;
                    }

                    throw new NullReferenceException("Content was null");
                }
                throw new HttpRequestException(
                    $"An error occured while getting content (code {DTO.code}), message: {DTO.message}");
            }
            catch (JsonException e)
            {
                throw new JsonException("An error from JSON", e);
            }
        }
        throw new HttpRequestException($"Error sending content: {await response.Content.ReadAsStringAsync()}");
    }
}