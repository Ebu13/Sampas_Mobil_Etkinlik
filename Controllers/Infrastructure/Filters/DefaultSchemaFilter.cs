using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Sampas_Mobil_Etkinlik.Controllers.Infrastructure.Filters;

public class DefaultSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        //2024-04-21T10:18:46.420Z
        if (context.Type == typeof(DateTime))
        {
            schema.Example = new OpenApiString(DateTime.UtcNow.ToString("s") + ".000Z");
        }
    }
}
