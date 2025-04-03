using System.Text.Json;
using ApiClient.Models;
using ApiClient.Models.Workspace;

namespace ApiClient.Providers;

public class WorkspaceProvider(string url, string accessToken)
{
    public async Task<List<Workspace>> GetAsync()
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        httpClient.BaseAddress = new Uri(url);
        var response = await httpClient.GetAsync("/api/workspace");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var DTO = JsonSerializer.Deserialize<ResponseObjectArray<Workspace>>(result);
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

    public async Task<WorkspaceFolder> GetFolderAsync(string workspaceId)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        httpClient.BaseAddress = new Uri(url);
        var response = await httpClient.GetAsync($"/api/workspace/{workspaceId}/folder");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var DTO = JsonSerializer.Deserialize<ResponseObject<WorkspaceFolder>>(result);
            if (DTO.code == 0)
            {
                if (DTO.data is not null)
                {
                    return DTO.data;
                }
                throw new NullReferenceException("Content was null");
            }
            throw new HttpRequestException($"An error occured while getting content (code {DTO.code}), message: {DTO.message}");
        }
        throw new HttpRequestException($"Error getting content: {await response.Content.ReadAsStringAsync()}");
    }
}