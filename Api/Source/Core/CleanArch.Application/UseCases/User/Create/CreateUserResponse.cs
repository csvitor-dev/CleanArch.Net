namespace CleanArch.Application.UseCases.User.Create;

public sealed record CreateUserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}