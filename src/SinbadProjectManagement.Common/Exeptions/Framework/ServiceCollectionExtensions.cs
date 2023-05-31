using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SinbadProjectManagement.Common.Exeptions.Framework
{
    public static class ServiceCollectionExtensions
    {
        public static void AddExeptionHandlers(this IServiceCollection services, Action<IExceptionHandlersBuilder> builderAction)
        {
            var builder = new ExceptionHandlersBuilder(services);
            builderAction(builder);
            builder.Build();

            services.AddSingleton<IExceptionHandler, DefaultExceptionHandler>();
            services.TryAddSingleton<IExceptionHandlersProvider, ExceptionHandlersProvider>();
        }
    }
}