using Microsoft.OpenApi.Models;
using SwaggerDocumentation.Api.Filters;

namespace SwaggerDocumentation.Api.Configuration
{
    public static class SwaggerConfiguration
    {
       public static void AddSwaggerGenConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Swagger Documentation. A title goes here",
                    Description = "API example with full Swagger documentation. A description goes here.",
                    Contact = new OpenApiContact
                    {
                        Url = new Uri(@"https://www.linkedin.com/in/viniciusterralino/"),
                        Name = "Vinicius Terra Lino"
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Some autentication token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new List<string>()
                    }
                });

                c.DescribeAllParametersInCamelCase();
                c.OperationFilter<HeaderFilter>();

                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var xmlDirectory = new DirectoryInfo(baseDirectory);
                foreach (var file in xmlDirectory.EnumerateFiles("*.xml")) { c.IncludeXmlComments(file.FullName); };

            });
        }
    }
}