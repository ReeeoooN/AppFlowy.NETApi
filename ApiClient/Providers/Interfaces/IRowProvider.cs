using ApiClient.Models.Database;
using ApiClient.Models.Database.Rows;

namespace ApiClient.Providers.Interfaces;

public interface IRowProvider
{
    public Task<List<DatabaseRowId>> GetRowsIdAsync(string workspaceId, string databaseId);

    public Task<List<DatabaseRowId>> GetUpdatedRowsIdAsync(string workspaceId, string databaseId);

    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId,
        List<DatabaseRowId> rowIds);

    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId, DatabaseRowId rowId);

    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (cells) in appflowy.</typeparam>
    public Task<List<DatabaseRow<T>>> GetAsync<T>(string workspaceId, string databaseId, string rowId);

    /// <typeparam name="T">The "T" parameter is your class that describes the model for custom fields (Cells) in appflowy.</typeparam>
    public Task<string> CreateAsync<T>(string workspaceId, string databaseId, CreateDatabaseRow<T> data);
}