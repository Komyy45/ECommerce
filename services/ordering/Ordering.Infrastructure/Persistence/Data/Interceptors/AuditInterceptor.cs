using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence.Data.Interceptors;

public sealed class AuditInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        return base.SavingChangesAsync(eventData, result).Result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = eventData.Context?.ChangeTracker.Entries<IAuditableEntity>();

        foreach (var entry in entries)
        {
            var entity = entry.Entity;
            switch (entry.State)
            {
                case EntityState.Modified:
                    entity.LastModifiedBy = "Youssef";
                    entity.LastModifiedOn = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entity.CreatedBy = "Youssef";
                    entity.CreatedOn = DateTime.UtcNow;
                    break;
            }
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}