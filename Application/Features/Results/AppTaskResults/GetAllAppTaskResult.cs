namespace Application.Features.Results.AppTaskResults;

public record GetAllAppTaskResult(
    int Id,
    string Title,
    string Description,
    string StatusName,
    string PersonelName,
    DateTime CreatedAt,
    string RequestTypeName,
    string RelatedUnitName);