namespace CleanArch.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset? CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
}