using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SinbadProjectManagement.Application.Shared.Exceptions.Handlers;
using SinbadProjectManagement.Common.Exeptions.Framework;

namespace SinbadProjectManagement.Application.Shared.Exceptions
{
    public static class ExceptionsServiceCollectionExtensions
    {
        public static void AddExceptions(this IServiceCollection services)
        {
            services.AddExeptionHandlers(builder => 
                builder.AddHandler<BadRequestExceptionHandler>()
                       .AddHandler<DeleteFailureExceptionHandler>()
                       .AddHandler<NotFoundExceptionHandler>()
                       .AddHandler<ValidationExceptionHandler>()
            );
        }
    }
}