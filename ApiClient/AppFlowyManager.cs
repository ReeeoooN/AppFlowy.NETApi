using ApiClient.Providers;
using ApiClient.Providers.Interfaces;

namespace ApiClient;

public class AppFlowyManager(string url, string token)
{
    public IWorkspaceProvider Workspaces = new WorkspaceProvider(url, token);
    public IDatabaseProvider Databases = new DatabaseProvider(url, token);
    public IFolderProvider Folders = new FolderProvider(url, token);
    public IRowProvider Rows = new RowProvider(url, token);
}