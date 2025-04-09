namespace Application.Common.Results.Abstract;

public interface IResult
{
    bool IsSuccess { get; }
    string Message { get; }
}
