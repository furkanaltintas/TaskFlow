using Application;
using Persistence;
using UI;
using UI.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//**
builder.Services.AddUIServices();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);




builder.Services.AddSignalR();
// >



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

#region Default
app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
#endregion

#region Route
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=home}/{action=index}/{id?}");

app.MapDefaultControllerRoute();
#endregion

app.MapHub<TaskFlowHub>("/taskHub");

app.Run();
