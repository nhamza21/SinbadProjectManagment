using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SinbadProjectManagement.Common.Exeptions.Framework
{
    public class ExceptionHandlersBuilder : IExceptionHandlersBuilder
    {
        private readonly ICollection<Type> _exceptionTypes;
        private readonly IServiceCollection _services;

        public ExceptionHandlersBuilder(IServiceCollection services)
        {
            _exceptionTypes = new List<Type>();
            _services = services;
        }
        public IExceptionHandlersBuilder AddHandler<TExceptionHandler>()
            where TExceptionHandler : IExceptionHandler
        {
            _exceptionTypes.Add(typeof(TExceptionHandler));
            return this;
        }
        public void Build()
        {
            foreach(var exceptionType in _exceptionTypes)
            {
                _services.AddSingleton(typeof(IExceptionHandler), exceptionType);
            }
        }
    }
}