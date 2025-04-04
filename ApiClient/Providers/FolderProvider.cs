using System.Text.Json;
using ApiClient.Models;
using ApiClient.Models.Workspace;

namespace ApiClient.Providers;

public class FolderProvider(string url, string token) : Provider(url, token)
{
    public async Task<WorkspaceFolder> GetAsync(string workspaceId)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        httpClient.BaseAddress = new Uri(url);
        var response = await httpClient.GetAsync($"/api/workspace/{workspaceId}/folder");
        var folder = await deserialization.Deserialize<WorkspaceFolder>(response);
        return folder;
    }
}