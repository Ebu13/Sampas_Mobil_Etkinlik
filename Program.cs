using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.Mvc;
using Sampas_Mobil_Etkinlik.Controllers.Infrastructure.Filters;
using Sampas_Mobil_Etkinlik.Extensions;
using Sampas_Mobil_Etkinlik.Core.Config;
using Sampas_Mobil_Etkinlik.Business.Mapping;
using Sampas_Mobil_Etkinlik.Controllers.Infrastructure.Middleware;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    // CORS yapılandırması
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyCorsPolicy", builder =>
        {
            builder.WithOrigins("http://192.168.34.13:5173") // İstemci URL'si
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials(); // Eğer credential kullanıyorsanız WithOrigins kullanmalısınız
        });
    });

    builder.Services.AddHttpClient();
    builder.Services.AddResponseCaching();

    builder.Services.ConfigureRateLimitingOptions();

    builder.Services.AddControllersWithViews(config =>
    {
        config.Filters.Add(new ModelStateActionFilter());
        config.Filters.Add<ApplicationLoggingActionFilter>();
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGenWithAuth();

    builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
    builder.Configuration.AddEnvironmentVariables();

    NLog.LogManager.Setup().LoadConfigurationFromAppSettings();
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var appSettingsSection = builder.Configuration.GetSection("AppSettings");
    var appSettings = appSettingsSection.Get<AppSettings>();

    var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
    var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
    builder.Services.Configure<JwtSettings>(jwtSettingsSection);

    builder.Services.AddAutoMapper(typeof(MappingProfile));
    builder.Services.AddServiceDescriptors(appSettings);
    builder.Services.AddAuthenticationWithJwt(jwtSettings);
    builder.Services.AddAuthorization();

    // HTTP ile çalışacak şekilde Kestrel yapılandırması
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(5262); // HTTP kullanımı
    });

    var app = builder.Build();

    app.UseMiddleware<GlobalErrorHandlingMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseIpRateLimiting();

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });

    // CORS policy kullanımı
    app.UseCors("MyCorsPolicy");

    app.UseResponseCaching();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
