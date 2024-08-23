using Microsoft.Extensions.Options;
using Sampas_Mobil_Etkinlik.Core.Config;

namespace Sampas_Mobil_Etkinlik.Controllers.Infrastructure.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<JwtSettings> jwtSettings)
        {
            _next = next;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"];
            await _next(context);
        }
    }
}
