namespace CleanArch.Domain.Entities;

public sealed class User : BaseEntity
{
    public string? Name { get; private set; }
    public string? Email { get; private set; }
}