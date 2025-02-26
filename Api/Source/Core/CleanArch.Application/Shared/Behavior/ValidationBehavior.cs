using FluentValidation;
using MediatR;

namespace CleanArch.Application.Shared.Behavior;

public sealed class ValidationBehavior
    <TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle
        (TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any() is false)
            return await next();
        
        var context = new ValidationContext<TRequest>(request);

        var query = from validator in validators select validator.ValidateAsync(context, cancellationToken);
        var results = await Task.WhenAll(query);

        var failures = results.SelectMany(result => result.Errors)
            .Where(error => error is not null).ToList();

        return failures.Count == 0 
            ? await next() 
            : throw new ValidationException(failures);
    }
}