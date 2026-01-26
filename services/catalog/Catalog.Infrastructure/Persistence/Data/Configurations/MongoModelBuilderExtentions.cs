using System.Reflection;

namespace Catalog.Infrastructure.Persistence.Data.Configurations;

public static class MongoModelBuilderExtensions
{
    public static void ApplyConfigurationsFromAssembly(
        this MongoModelBuilder builder,
        Assembly assembly)
    {
        var configTypes = assembly.GetTypes()
            .Where(t =>
                !t.IsAbstract &&
                !t.IsInterface &&
                t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() ==
                    typeof(IMongoEntityConfiguration<>)));

        foreach (var type in configTypes)
        {
            var config = Activator.CreateInstance(type);

            var entityType = type.GetInterfaces()
                .First()
                .GetGenericArguments()
                .First();

            var method = typeof(MongoModelBuilder)
                .GetMethod(nameof(MongoModelBuilder.ApplyConfiguration))
                .MakeGenericMethod(entityType);

            method.Invoke(builder, new[] { config });
        }
    }
}