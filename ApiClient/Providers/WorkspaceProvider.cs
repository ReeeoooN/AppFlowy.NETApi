using System.Text.Json;
using ApiClient.Models;
using ApiClient.Models.Workspace;
using ApiClient.Providers.Interfaces;

namespace ApiClient.Providers;

internal class WorkspaceProvider(string url, string token) : Provider(url, token), IWorkspaceProvider
{
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