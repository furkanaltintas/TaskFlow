using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class AppTaskConfiguration : IEntityTypeConfiguration<AppTask>
{
    public void Configure(EntityTypeBuilder<AppTask> builder)
    {
        builder.HasData(
            new AppTask
            {
                Id = 1,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 1,
                RequestTypeId = 1,
                RelatedUnitId = 1,
                TaskCode = "#BT-250723001",
                Title = "Web sitesinde iletişim formu çalışmıyor",
                Description = "Kullanıcılar iletişim formunu doldurduktan sonra hata mesajı alıyor."
            },
            new AppTask
            {
                Id = 2,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 2,
                RequestTypeId = 3,
                RelatedUnitId = 3,
                TaskCode = "#BT-250723002",
                Title = "Yeni çalışan için e-posta hesabı oluşturulması",
                Description = "Ayşe Yılmaz adına bir e-posta adresi tanımlanması gerekiyor."
            },
            new AppTask
            {
                Id = 3,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 2,
                RequestTypeId = 2,
                RelatedUnitId = 2,
                TaskCode = "#BT-250723003",
                Title = "XRM sisteminde kayıt güncellenemiyor",
                Description = "Kayıt güncelleme işlemi sırasında sistem hata veriyor."
            },
            new AppTask
            {
                Id = 4,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 3,
                RequestTypeId = 3,
                RelatedUnitId = 3,
                TaskCode = "#BT-250723004",
                Title = "Yeni barkod okuyucu satın alma talebi",
                Description = "Depo personeli için barkod okuyucu satın alınmalı."
            },
            new AppTask
            {
                Id = 5,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 3,
                RequestTypeId = 1,
                RelatedUnitId = 4,
                TaskCode = "#BT-250723005",
                Title = "Satış raporları excel formatında alınamıyor",
                Description = "Rapor alım ekranında Excel seçeneği çalışmıyor"
            },
            new AppTask
            {
                Id = 6,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 2,
                RequestTypeId = 2,
                RelatedUnitId = 2,
                TaskCode = "#BT-250723006",
                Title = "Kullanıcı erişim yetkisi tanımlama",
                Description = "Mehmet Demir'e XRM sistemi görüntüleme yetkisi verilmeli."
            },
            new AppTask
            {
                Id = 7,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 1,
                RequestTypeId = 1,
                RelatedUnitId = 4,
                TaskCode = "#BT-250723007",
                Title = "Web sitesi renk uyumsuzluğu",
                Description = "Yeni tasarım sonrası bazı bölümler okunamıyor."
            },
            new AppTask
            {
                Id = 8,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 3,
                RequestTypeId = 1,
                RelatedUnitId = 4,
                TaskCode = "#BT-250723008",
                Title = "Satış paneli yavaş çalışıyor",
                Description = "Satış ekibi panele erişmekte zorluk yaşıyor, performans çok düşük."
            },
            new AppTask
            {
                Id = 9,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 2,
                RequestTypeId = 2,
                RelatedUnitId = 3,
                TaskCode = "#BT-250723009",
                Title = "Donanım envanter listesi güncelleme",
                Description = "Yeni alınan donanımlar sisteme işlenmeli."
            },
            new AppTask
            {
                Id = 10,
                UserId = 1,
                TaskStatusId = 1,
                PriorityId = 1,
                RequestTypeId = 2,
                RelatedUnitId = 2,
                TaskCode = "#BT-250723010",
                Title = "XRM kullanıcıları için eğitim talebi",
                Description = "Satış personeline XRM eğitimi verilmesi talep ediliyor."
            });
    }
}