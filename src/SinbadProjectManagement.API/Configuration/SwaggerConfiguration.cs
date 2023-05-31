using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SinbadProjectManagement.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // services.AddSwaggerGen(c =>
            // {
            //     // Configure SwaggerGen options
            //     c.OperationFilter<SwaggerDefaultValuesOperationFilter>();
            // });

            services.AddSwaggerGen();
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

        }

        public static IApplicationBuilder UseSwaggerConfiguration(
            this IApplicationBuilder app)
        {
            var versionDescriptionProvider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
                {
                    o.SwaggerEndpoint($"swagger/{description.GroupName}/swagger.json", description.ApiVersion.ToString());
                }

                o.RoutePrefix = string.Empty;
            });

            return app;
        }
    }


    // public class SwaggerDefaultValuesOperationFilter : IOperationFilter
    // {
    //     public void Apply(OpenApiOperation operation, OperationFilterContext context)
    //     {
    //         var apiVersion = context.ApiDescription.GetApiVersion();
    //         var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "version");
    
    //         if (versionParameter != null)
    //         {
    //             operation.Parameters.Remove(versionParameter);
    //         }
    
    //         operation.Parameters.Add(new OpenApiParameter
    //         {
    //             Name = "version",
    //             In = ParameterLocation.Path,
    //             Required = true,
    //             Schema = new OpenApiSchema { Type = "string", Default = new OpenApiString(apiVersion.ToString()) }
    //         });
    //     }
    // }
}