using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SinbadProjectManagement.Application.Shared.Seed;

namespace SinbadProjectManagement.API.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetService<IMediator>();
                mediator.Send(new SeedCommand());
            }
        }
    }
}