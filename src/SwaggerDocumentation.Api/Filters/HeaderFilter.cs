using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerDocumentation.Api.Filters
{
    public class HeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-correlation-id",
                In = ParameterLocation.Header,
                Required = true,
                Description = "Correlation Id of the request",
                Schema = new OpenApiSchema
                {
                    Type = typeof(Guid).ToString(),
                    Example = new OpenApiString("68c91192-2d83-4eff-b273-cb55626671a3")
                }
            });
        }
    }
}