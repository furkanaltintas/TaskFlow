using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace UI;

public static class ServiceRegistration
{
    public static void AddUIServices(this IServiceCollection services)
    {
        #region Security
        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.FromMinutes(15);
            // Default değeri 30 dakikadır. 30 dakikada bir kontrol eder sistemi
        });
        #endregion

        #region Routing
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });
        #endregion

        #region Auth
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(30);
            options.Cookie.HttpOnly = true;
        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.Name = "PortfolioCookie"; // Cookie'nin tarayıcıda gözükeceği adı
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            options.ExpireTimeSpan = TimeSpan.FromDays(14); // Cookie'nin ne kadar süre ayakta kalacak
            options.LoginPath = new PathString("/Auth/SignIn");
            options.LogoutPath = new PathString("/Auth/SignOut");
            options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
            options.SlidingExpiration = true;
            options.Events = new CookieAuthenticationEvents // Cookie Kimlik Doğrulama yöntemiyle ilişkili olayları özelleştirmemizi sağlayan bir sınıftır.
            {
                OnRedirectToLogin = context =>
                {
                    context.Response.Redirect("/"); // Kullanıcı giriş yapmamışsa her zaman anasayfaya yönlendir.

                    return Task.CompletedTask;
                }
            };
        });
        #endregion
    }
}