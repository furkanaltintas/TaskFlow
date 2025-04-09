namespace Application.Features.Results.AppTaskResults;

public record GetAppTaskDetailResult(
    int Id,
    string TaskStatusName,
    string PersonelName,
    string RequestType,
    string DemandRelatedUnit,
    string Detail,
    string YapilanIslem,
    string BilgiVerilecekKisiler,
    DateTime CreatedAt,
    string BildirimKapatilmaTarihi,
    string Gorsel1,
    string Gorsel2,
    string Gorsel3,
    string Gorsel4,
    string Dokuman,
    string CozumSuresi); // dakika cinsinden