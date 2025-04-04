using ApiClient.Models.Workspace;

namespace ApiClient.Providers.Interfaces;

public interface IWorkspaceProvider
{
    public Task<List<Workspace>> GetAsync();
}