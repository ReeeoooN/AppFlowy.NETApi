using System.Text.Json;
using ApiClient.Models;
using ApiClient.Models.Workspace;

namespace ApiClient.Providers;

public class WorkspaceProvider(string url, string token) : Provider(url, token)  
{
    public FolderProvider Folders = new FolderProvider(url, token);
    public async Task<List<Workspace>> GetAsync()
    {
        using var httpClient = new HttpClient(); 
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}"); 
        httpClient.BaseAddress = new Uri(url); 
        var response = await httpClient.GetAsync("/api/workspace"); 
        var workspaces = await deserialization.Deserialize<Workspace[]>(response); 
        return workspaces.ToList();
    }

    
}