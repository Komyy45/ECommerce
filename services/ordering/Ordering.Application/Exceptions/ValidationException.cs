using FluentValidation.Results;

namespace Ordering.Domain.Exceptions;

public sealed class ValidationException : Exception
{
    public Dictionary<string, List<string>> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> errors)
    {
        Errors = errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToList()
            );
    }
}