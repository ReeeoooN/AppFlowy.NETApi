using System.Text.Json;
using ApiClient;
using Tests.TestModels;

namespace Tests;

public class Tests
{
    private static string Base = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
    private static EnvModel envModel = JsonSerializer.Deserialize<EnvModel>(File.ReadAllText(Path.Combine(Base, "TestEnv.json")));
    public AppFlowyManager appFlowyManager = new AppFlowyManager(envModel.Url, envModel.Token);

    [Test]
    public async Task WorkspaceTest()
    {
        var workspace = await appFlowyManager.Workspaces.GetAsync();
        Assert.That(workspace, Is.Not.Null, "Workspace was null");
    }

    [Test]
    public async Task FolderTest()
    {
        var folder = appFlowyManager.Workspaces.Folders.GetAsync(envModel.Wokspace);
        Assert.That(folder, Is.Not.Null, "Folder was null");
    }

    [Test]
    public async Task DatabaseTest()
    {
        var database = await appFlowyManager.Databases.GetAsync(envModel.Wokspace);
        Assert.That(database, Is.Not.Null, "Database was null");
    }

    [Test]
    public async Task RowTest()
    {
        var rowids = await appFlowyManager.Databases.Rows.GetRowsIdAsync(envModel.Wokspace, envModel.Database);
        var rows = await appFlowyManager.Databases.Rows.GetAsync<TestCells>(envModel.Wokspace, envModel.Database, rowids);
        Assert.That(rows, Is.Not.Null, "Rows was null");
    }
}