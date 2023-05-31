using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Common.Exeptions.Framework;

namespace SinbadProjectManagement.Application.Shared.Exceptions.Handlers
{
    public class DeleteFailureExceptionHandler : ExceptionHandler<DeleteFailureException>
    {
        private readonly ILogger<DeleteFailureExceptionHandler>  _logger;

        public DeleteFailureExceptionHandler(ILogger<DeleteFailureExceptionHandler> logger)
        {
            _logger = logger;
        }

        public override ErrorMessage HandleException(Exception exception)
        {
            _logger.LogWarning(exception.Message, exception);            
            return new ErrorMessage(409, exception.Message);
        }
    }
}