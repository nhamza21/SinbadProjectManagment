using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Common.Exeptions.Framework;

namespace SinbadProjectManagement.Application.Shared.Exceptions.Handlers
{
    public class NotFoundExceptionHandler : ExceptionHandler<NotFoundException>
    {
        private readonly ILogger<NotFoundExceptionHandler> _logger;

        public NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger)
        {
            _logger = logger;
        }

        public override ErrorMessage HandleException(Exception exception)
        {
            _logger.LogWarning(exception.Message,exception);
            var notFoundException = (NotFoundException)exception;
            return new ErrorMessage(notFoundException.Code,exception.Message);
        }
    }
}