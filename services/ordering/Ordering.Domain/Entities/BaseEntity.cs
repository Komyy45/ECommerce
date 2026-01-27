namespace Ordering.Domain.Entities;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; } = default!;
    public DateTime LastModifiedOn { get; set; }
    public string LastModifiedBy { get; set; } = default!;
}