using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SinbadProjectManagement.Common.Exeptions.Framework
{
    public class DefaultExceptionHandler : ExceptionHandler<Exception>
    {
        private readonly ILogger<DefaultExceptionHandler> _logger;

        public DefaultExceptionHandler(ILogger<DefaultExceptionHandler> logger)
        {
            _logger = logger;
        }

        public override ErrorMessage HandleException(Exception exception)
        {
            _logger.LogError(exception.Message,exception);

            return new ErrorMessage(500,exception.Message);
        }
    }
}