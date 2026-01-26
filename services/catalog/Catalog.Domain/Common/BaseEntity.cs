namespace Catalog.Domain.Common;

public abstract class BaseEntity<TKey>
where TKey : IComparable<TKey>
{
    public TKey Id { get; set; } = default!;
}