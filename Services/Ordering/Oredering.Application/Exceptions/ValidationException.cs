using System;
using FluentValidation.Results;

namespace Ordering.Application.Extensions;

public class ValidationException : ApplicationException
{
    public Dictionary<string, string[]> Error { get; private set; }
    public ValidationException():base("One or more validation error(s) occurred")
    {
        Error = new Dictionary<string, string[]>();
    }
    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Error = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                        .ToDictionary(failures => failures.Key, failures => failures.ToArray());
        
    }

}
