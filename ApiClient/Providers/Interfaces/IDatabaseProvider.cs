using ApiClient.Models.Database;

namespace ApiClient.Providers.Interfaces;

public interface IDatabaseProvider
{
    public Task<List<Database>> GetAsync(string workspaceid);
}