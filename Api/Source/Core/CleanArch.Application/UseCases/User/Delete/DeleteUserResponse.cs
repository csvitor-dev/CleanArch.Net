namespace CleanArch.Application.UseCases.User.Delete;

public sealed record DeleteUserResponse
    (Guid Id, string Email, string Name);