namespace CleanArch.Application.UseCases.User.GetAll;

public sealed record GetAllUserResponse
    (Guid Id, string Email, string Name);