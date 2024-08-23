
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
    /*int workerThreads;//
    int portThreads;//

    ThreadPool.GetMaxThreads(out workerThreads, out portThreads);//
    ThreadPool.SetMaxThreads(workerThreads, 8000);//
    ThreadPool.GetMaxThreads(out workerThreads, out portThreads);//*/

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddCors();

    /*builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("https://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));
*/
    builder.Services.AddHsts(options =>
    {
        options.IncludeSubDomains = true;
        options.MaxAge = TimeSpan.FromMinutes(5);
    });

    /*builder.Services.AddHttpsRedirection(options => {
		options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
		options.HttpsPort = 7218;
	});
	*/


    builder.Services.AddHttpClient();
    builder.Services.AddResponseCaching();

    builder.Services.ConfigureRateLimitingOptions();

    // Add services to the container.

    //builder.Services.AddControllers();

    builder.Services.AddControllersWithViews(config =>
    {
        config.Filters.Add(new ModelStateActionFilter());
        config.Filters.Add<ApplicationLoggingActionFilter>();
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGenWithAuth();


    builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
    builder.Configuration.AddEnvironmentVariables();

    NLog.LogManager.Setup().LoadConfigurationFromAppSettings();
    // NLog: Setup NLog for Dependency injection
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


    var app = builder.Build();

    app.UseMiddleware<GlobalErrorHandlingMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseIpRateLimiting();

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });

    app.UseCors(x => x
    //.WithOrigins()
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );

    app.UseResponseCaching();
    app.UseAuthentication();
    
    app.UseAuthorization();
    app.UseMiddleware<JwtMiddleware>();

    //app.UseStaticFiles(new StaticFileOptions()
    //{
    //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    //    RequestPath = new PathString("/Resources")
    //});



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