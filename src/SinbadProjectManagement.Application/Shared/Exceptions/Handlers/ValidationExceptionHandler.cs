using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Common.Exeptions.Framework;

namespace SinbadProjectManagement.Application.Shared.Exceptions.Handlers
{
    public class ValidationExceptionHandler : ExceptionHandler<SinbadValidationException>
    {
        private readonly ILogger<ValidationExceptionHandler> _logger;
        private readonly StringBuilder _serializer;

        public ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
        {
            _logger = logger;
            _serializer = new StringBuilder();
        }

        public override ErrorMessage HandleException(Exception exception)
        {
            _logger.LogInformation(exception.Message, exception);
            var validationException = (SinbadValidationException)exception;
            return new ErrorMessage(400, buildMessage(validationException));
        }

        private string buildMessage(SinbadValidationException validationException)
        {
            _serializer.Clear();
            _serializer.Append(validationException.Message)
                .Append(Environment.NewLine)
                .Append(JsonConvert.SerializeObject(validationException.Failures));

            return _serializer.ToString();
        }
    }
}