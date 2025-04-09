using Application.Features.Commands.AppTaskCommands;
using Application.Features.Results.AppTaskResults;
using Domain.Entitites;

namespace Application.Mappings;

public static class AppTaskMappings
{
    public static GetAppTaskDetailResult ToGetAppTaskDetailResult(this AppTask appTask)
    {
        return new GetAppTaskDetailResult(
            Id: appTask.Id,
            TaskStatusName: appTask.TaskStatus!.Name,
            PersonelName: $"{appTask.User.FirstName} {appTask.User.LastName}",
            RequestType: appTask.RequestType!.Name,
            DemandRelatedUnit: appTask.RelatedUnit!.Name,
            Detail: appTask.Description,
            YapilanIslem: "11 Nisan Cuma günü sinyal kalitesi ölçülecek ve gerekliyse ilave AP eklenecek.",
            BilgiVerilecekKisiler: "Furkan Altıntaş, Berke Altıntaş, Berkay Akar",
            CreatedAt: appTask.CreatedAt,
            BildirimKapatilmaTarihi: string.Empty,
            Gorsel1: string.Empty,
            Gorsel2: string.Empty,
            Gorsel3: string.Empty,
            Gorsel4: string.Empty,
            Dokuman: string.Empty,
            CozumSuresi: "-1062606788,63");
    }

    public static GetAllAppTaskResult ToGetAllAppTaskResult(this AppTask appTask)
    {
        return new GetAllAppTaskResult(
            Id: appTask.Id,
            Title: appTask.Title,
            Description: appTask.Description,
            StatusName: appTask.TaskStatus!.Name,
            PersonelName: appTask.User!.UserName!,
            CreatedAt: appTask.CreatedAt,
            RequestTypeName: appTask.RequestType!.Name,
            RelatedUnitName: appTask.RelatedUnit!.Name);
    }

    public static AppTask ToCreateAppTaskResult(this CreateAppTaskCommandRequest createAppTaskCommandRequest)
    {
        return new AppTask
        {
            Title = createAppTaskCommandRequest.Title,
            Description = createAppTaskCommandRequest.Description,
            PriorityId = createAppTaskCommandRequest.PriorityId,
            UserId = createAppTaskCommandRequest.AppUserId
        };
    }
}