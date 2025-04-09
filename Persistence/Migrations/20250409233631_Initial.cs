using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatedUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RefreshTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TaskStatusId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    RelatedUnitId = table.Column<int>(type: "int", nullable: false),
                    TaskCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTasks_AppTaskStatuses_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalTable: "AppTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTasks_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTasks_RelatedUnits_RelatedUnitId",
                        column: x => x.RelatedUnitId,
                        principalTable: "RelatedUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTasks_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_AppTasks_AppTaskId",
                        column: x => x.AppTaskId,
                        principalTable: "AppTasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskAssigmentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppTaskId = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssigmentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAssigmentInfos_AppTasks_AppTaskId",
                        column: x => x.AppTaskId,
                        principalTable: "AppTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppTaskId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskComments_AppTasks_AppTaskId",
                        column: x => x.AppTaskId,
                        principalTable: "AppTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppTaskId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChagedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskHistories_AppTasks_AppTaskId",
                        column: x => x.AppTaskId,
                        principalTable: "AppTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppTaskId = table.Column<int>(type: "int", nullable: false),
                    ImagePath1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskMedias_AppTasks_AppTaskId",
                        column: x => x.AppTaskId,
                        principalTable: "AppTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppTaskId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskRatings_AppTasks_AppTaskId",
                        column: x => x.AppTaskId,
                        principalTable: "AppTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppTaskId = table.Column<int>(type: "int", nullable: false),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskReports_AppTasks_AppTaskId",
                        column: x => x.AppTaskId,
                        principalTable: "AppTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppTaskStatuses",
                columns: new[] { "Id", "ColorCode", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, "New", false, "Yeni" },
                    { 2, null, "In Progress", false, "Devam Ediyor" },
                    { 3, null, "Completed", false, "Tamamlandı" },
                    { 4, null, "Closed", false, "Kapatıldı" },
                    { 5, null, "On Hold", false, "Beklemede" },
                    { 6, null, "Cancelled", false, "İptal Edildi" },
                    { 7, null, "Reopened", false, "Tekrar Açıldı" },
                    { 8, null, "Awaiting Approval", false, "Onay Bekliyor" },
                    { 9, null, "Under Investigation", false, "İnceleniyor" },
                    { 10, null, "Pending", false, "Beklemede" }
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Definition" },
                values: new object[,]
                {
                    { 1, "High" },
                    { 2, "Medium" },
                    { 3, "Low" },
                    { 4, "Urgent" },
                    { 5, "Critical" },
                    { 6, "Normal" },
                    { 7, "Very High" },
                    { 8, "Low-Moderate" },
                    { 9, "Backlog" },
                    { 10, "Emergency" }
                });

            migrationBuilder.InsertData(
                table: "RelatedUnits",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Web" },
                    { 2, false, "XRM" },
                    { 3, false, "Donanım" },
                    { 4, false, "Satış" },
                    { 5, false, "IT" },
                    { 6, false, "Finans" },
                    { 7, false, "HR" },
                    { 8, false, "Operasyon" },
                    { 9, false, "Pazarlama" },
                    { 10, false, "Müşteri Destek" }
                });

            migrationBuilder.InsertData(
                table: "RequestTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Arıza" },
                    { 2, false, "Hizmet Talebi" },
                    { 3, false, "Problem" },
                    { 4, false, "Değişiklik Talebi" },
                    { 5, false, "Maintenance" },
                    { 6, false, "Complaint" },
                    { 7, false, "Bug" },
                    { 8, false, "Feature Request" },
                    { 9, false, "Inquiry" },
                    { 10, false, "Support" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "873b7636-0ffc-484b-a1c0-aebbe2ec586f", "Administrator with full permissions", "Admin", "ADMIN" },
                    { 2, "884bae14-7164-417d-b322-425ae0ffae8f", "Role with supervisory access", "Supervisor", "SUPERVISOR" },
                    { 3, "7bcfc3d1-62a6-4949-aeed-60aa9343e9b6", "Role for support team members", "Support Specialist", "SUPPORT SPECIALIST" },
                    { 4, "07724dfc-4884-4696-af54-f29cec9eb673", "General user role", "End User", "END USER" },
                    { 5, "3e241c6c-4cfa-4e6e-aa5b-031def34fd45", "Role for managers", "Manager", "MANAGER" },
                    { 6, "5c3dcf08-8d15-49c2-8895-90543b2f8f4a", "Role for team leaders", "Team Lead", "TEAM LEAD" },
                    { 7, "8e054ebe-ff80-43cf-82df-d89ffa506018", "Role for technical staff", "Technician", "TECHNICIAN" },
                    { 8, "ad7a6a20-c489-453b-ace6-ab27a78cc9bc", "Role for customers", "Customer", "CUSTOMER" },
                    { 9, "06cd97ea-c4ec-47c3-b6b6-e4c2894ad6b6", "Role for HR department", "HR", "HR" },
                    { 10, "4c189cab-3558-497d-a3f9-235016ddeb47", "Role for IT support staff", "IT Support", "IT SUPPORT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "12345678", "ahmet.yilmaz@example.com", true, "Ahmet", "Yılmaz", false, null, "AHMET.YILMAZ@EXAMPLE.COM", "AHMET.YILMAZ", "AQAAAAIAAYagAAAAEK4YxFVcXBI/oV6l6eb1LQeQdbktEWBfiQfzXM/nYzLMKv+l/1Z2GuWOJYhdppXIjA==", null, false, "sample-refresh-token", new DateTime(2025, 5, 9, 23, 36, 30, 810, DateTimeKind.Utc).AddTicks(4664), "cbb55583-cde5-4bd3-97b6-dae8d615eed4", false, "ahmet.yilmaz" });

            migrationBuilder.InsertData(
                table: "AppTasks",
                columns: new[] { "Id", "ClosedAt", "CompletedAt", "CreatedAt", "DeletedAt", "Description", "ExpectedCompletionDate", "IsCompleted", "IsDeleted", "PriorityId", "RelatedUnitId", "RequestTypeId", "TaskCode", "TaskStatusId", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kullanıcılar iletişim formunu doldurduktan sonra hata mesajı alıyor.", null, false, false, 1, 1, 1, "#BT-250723001", 1, "Web sitesinde iletişim formu çalışmıyor", null, 1 },
                    { 2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ayşe Yılmaz adına bir e-posta adresi tanımlanması gerekiyor.", null, false, false, 2, 3, 3, "#BT-250723002", 1, "Yeni çalışan için e-posta hesabı oluşturulması", null, 1 },
                    { 3, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kayıt güncelleme işlemi sırasında sistem hata veriyor.", null, false, false, 2, 2, 2, "#BT-250723003", 1, "XRM sisteminde kayıt güncellenemiyor", null, 1 },
                    { 4, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Depo personeli için barkod okuyucu satın alınmalı.", null, false, false, 3, 3, 3, "#BT-250723004", 1, "Yeni barkod okuyucu satın alma talebi", null, 1 },
                    { 5, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rapor alım ekranında Excel seçeneği çalışmıyor", null, false, false, 3, 4, 1, "#BT-250723005", 1, "Satış raporları excel formatında alınamıyor", null, 1 },
                    { 6, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mehmet Demir'e XRM sistemi görüntüleme yetkisi verilmeli.", null, false, false, 2, 2, 2, "#BT-250723006", 1, "Kullanıcı erişim yetkisi tanımlama", null, 1 },
                    { 7, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeni tasarım sonrası bazı bölümler okunamıyor.", null, false, false, 1, 4, 1, "#BT-250723007", 1, "Web sitesi renk uyumsuzluğu", null, 1 },
                    { 8, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Satış ekibi panele erişmekte zorluk yaşıyor, performans çok düşük.", null, false, false, 3, 4, 1, "#BT-250723008", 1, "Satış paneli yavaş çalışıyor", null, 1 },
                    { 9, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Yeni alınan donanımlar sisteme işlenmeli.", null, false, false, 2, 3, 2, "#BT-250723009", 1, "Donanım envanter listesi güncelleme", null, 1 },
                    { 10, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Satış personeline XRM eğitimi verilmesi talep ediliyor.", null, false, false, 1, 2, 2, "#BT-250723010", 1, "XRM kullanıcıları için eğitim talebi", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { 1, 1, "IdentityUserRole<int>" });

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_PriorityId",
                table: "AppTasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_RelatedUnitId",
                table: "AppTasks",
                column: "RelatedUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_RequestTypeId",
                table: "AppTasks",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_TaskStatusId",
                table: "AppTasks",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_UserId",
                table: "AppTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_AppTaskId",
                table: "AuditLogs",
                column: "AppTaskId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssigmentInfos_AppTaskId",
                table: "TaskAssigmentInfos",
                column: "AppTaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_AppTaskId",
                table: "TaskComments",
                column: "AppTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_AppTaskId",
                table: "TaskHistories",
                column: "AppTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMedias_AppTaskId",
                table: "TaskMedias",
                column: "AppTaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskRatings_AppTaskId",
                table: "TaskRatings",
                column: "AppTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskReports_AppTaskId",
                table: "TaskReports",
                column: "AppTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "TaskAssigmentInfos");

            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "TaskHistories");

            migrationBuilder.DropTable(
                name: "TaskMedias");

            migrationBuilder.DropTable(
                name: "TaskRatings");

            migrationBuilder.DropTable(
                name: "TaskReports");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "AppTasks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AppTaskStatuses");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "RelatedUnits");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
