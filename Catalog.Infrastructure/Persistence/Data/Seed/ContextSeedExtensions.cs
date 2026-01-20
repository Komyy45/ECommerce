using System.Text.Json;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Persistence.Data.Seed;

public static class ContextSeedExtensions
{
    public static async Task SeedAsync<TSeed>(this IMongoCollection<TSeed> collection, string path)
    {
        var hasData = await collection.CountDocumentsAsync(_ => true);

        if (hasData > 0) return;
        
        var dataText = await File.ReadAllTextAsync(path);

        var data = JsonSerializer.Deserialize<IEnumerable<TSeed>>(dataText);

        var enumerable = data?.ToList();
        
        if (enumerable is null || !enumerable.Any()) return;

        await collection.InsertManyAsync(enumerable);
    }
}