namespace CleanArch.Application.UseCases.User.Update;

public sealed record UpdateUserResponse
    (Guid Id, string Email, string Name);