namespace CleanArch.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    public DateTimeOffset? CreatedOn { get; protected set; }
    public DateTimeOffset? UpdatedOn { get; protected set; }
    public DateTimeOffset? DeletedOn { get; protected set; }
}