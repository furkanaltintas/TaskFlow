using Application.Common.Results.Abstract;

namespace Application.Common.Results.Concrete;

public class Result : IResult
{
    public Result(bool success, string message) : this(success)
    {
        Message = message;
    }

    public Result(bool success)
    {
        IsSuccess = success;
        Message = string.Empty;
    }

    public bool IsSuccess { get; }

    public string Message { get; }
}