using ApiClient.Models.Workspace;

namespace ApiClient.Providers.Interfaces;

public interface IFolderProvider
{
    public Task<WorkspaceFolder> GetAsync(string workspaceId);
}