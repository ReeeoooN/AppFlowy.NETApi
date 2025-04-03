using ApiClient.Providers;

namespace ApiClient;

public class AppFlowyManager(string url, string accessToken)
{
    public WorkspaceProvider Workspaces = new WorkspaceProvider(url, accessToken);
    public DatabaseProvider Databases = new DatabaseProvider(url, accessToken);
}