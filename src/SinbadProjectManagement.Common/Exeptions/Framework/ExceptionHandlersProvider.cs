using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinbadProjectManagement.Common.Exeptions.Framework
{
    public class ExceptionHandlersProvider : IExceptionHandlersProvider
    {
        private readonly IDictionary<Type,IExceptionHandler> _handlers;

        public ExceptionHandlersProvider(IEnumerable<IExceptionHandler> handlers)
        {
            _handlers = handlers.ToDictionary(h => h.ExceptionType);
        }

        public IExceptionHandler GetHandler(Type exceptionType)
        {
            return _handlers.TryGetValue(exceptionType, out var exceptionHandler) 
                    ? exceptionHandler 
                    : _handlers[typeof(Exception)];
        }
    }
}