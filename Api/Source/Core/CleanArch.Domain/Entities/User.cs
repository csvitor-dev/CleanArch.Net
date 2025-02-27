namespace CleanArch.Domain.Entities;

public sealed class User : BaseEntity
{
    public string? Name { get; private set; }
    public string? Email { get; private set; }

    public void SetProperties(User user)
    {
        Name = user.Name;
        Email = user.Email;
    }
}