using System;
using FluentValidation;
using MediatR;

namespace Ordering.Application.Behaviour;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    // This will collect fluent validators and run before handler.
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this._validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            // This will run all the validation rules one by one and returns the validation result.
            var validationsResults = await Task.WhenAll( _validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            // now need to check for any failure
            var failure = validationsResults.SelectMany(e => e.Errors).Where(f => f != null).ToList();
            if(failure.Count != 0)
            {
                throw new ValidationException(failure);
            }
        }
        return await next();
    }
}
