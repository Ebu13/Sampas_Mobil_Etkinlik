using AspNetCoreRateLimit;
using Dapper;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Sampas_Mobil_Etkinlik.Core.Config;
using Sampas_Mobil_Etkinlik.Data.Attributes;
using Sampas_Mobil_Etkinlik.Data.Repositories.Context;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using static Dapper.SqlMapper;

namespace Sampas_Mobil_Etkinlik.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceDescriptors(this IServiceCollection services, AppSettings appSettings)
        {

            services.AddSingleton<DapperContext>();

            //Repositories
            var assembly = Assembly.GetExecutingAssembly();

            var repositoryTypes = assembly.GetTypes()
                .Where(t => t.Namespace != null && t.GetInterfaces()
                .Any(i => i.Name.EndsWith("Repository")))
                .ToList();

            foreach (var type in repositoryTypes)
            {
                var interfaceType = type.GetInterfaces()
                    .FirstOrDefault(i => i.Name.EndsWith("Repository"));
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, type);
                }
            }


            //Column Attributes
            var entityTypes = assembly.GetTypes()
                                  .Where(t => t.IsClass && t.GetProperties()
                                  .Any(p => p.GetCustomAttribute<ColumnAttribute>() != null));

            foreach (var entityType in entityTypes)
            {
                var mapperType = typeof(ColumnAttributeTypeMapper<>).MakeGenericType(entityType);
                var mapperInstance = Activator.CreateInstance(mapperType);

                var setTypeMapMethod = typeof(SqlMapper).GetMethod("SetTypeMap", new[] { typeof(Type), typeof(ITypeMap) });
                var parameters = new object[] { entityType, mapperInstance };

                setTypeMapMethod.Invoke(null, parameters);
            }


            //Business


            var businessTypes = assembly.GetTypes()
                .Where(t => t.Namespace != null && t.GetInterfaces().Any(i => i.Name.EndsWith("Business")))
                .ToList();

            foreach (var type in businessTypes)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault(i => i.Name.EndsWith("Business"));
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, type);
                }
            }



            return services;



        }

        public static IServiceCollection AddAuthenticationWithJwt(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddAuthentication(i =>
            {
                i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
        ClockSkew = TimeSpan.Zero
    };
    options.SaveToken = true;
    options.Events = new JwtBearerEvents();
    options.Events.OnMessageReceived = context =>
    {
        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            context.Token = token;
        }
        return Task.CompletedTask;
    };
});


            return services;
        }


        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>()
            {
                new RateLimitRule()
                {
                    Endpoint = "*",
                    Limit = 100,
                    Period = "1m"
                }
            };

            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });

            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }

        public static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
        {
            var securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JSON Web Token based security",
            };

            var securityReq = new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                TermsOfService = new Uri("http://www.example.com"),
            };

            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", info);
                o.AddSecurityDefinition("Bearer", securityScheme);
                o.AddSecurityRequirement(securityReq);
            });

            return services;
        }


    }
}
