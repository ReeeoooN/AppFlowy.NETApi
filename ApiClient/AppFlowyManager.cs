using ApiClient.Providers;

namespace ApiClient;

public class AppFlowyManager(string url, string token) : Provider(url , token)
{
    public WorkspaceProvider Workspaces = new WorkspaceProvider(url, token);
    public DatabaseProvider Databases = new DatabaseProvider(url, token);
}