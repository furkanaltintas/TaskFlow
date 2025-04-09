using FluentValidation.Results;

namespace Application.Extensions;

public static class ValidationExtensions
{
    public static List<ValidationError> ToMap(this IEnumerable<ValidationFailure> errors)
    {
        List<ValidationError> result = new();

        foreach (var error in errors)
            result.Add(new(error.PropertyName, error.ErrorMessage));

        return result;
    }
}

public class ValidationError
{
    public ValidationError()
    {
        PropertyName = string.Empty;
        ErrorMessage = string.Empty;
    }

    public ValidationError(string propertyName, string errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }

    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }
}