using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SinbadProjectManagement.Common.Exeptions.Framework;

namespace SinbadProjectManagement.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly IExceptionHandlersProvider _exceptionHandlersProvider;

        public ErrorController(IExceptionHandlersProvider exceptionHandlersProvider)
        {
            _exceptionHandlersProvider = exceptionHandlersProvider;
        }

        [Route("error")]
        public IActionResult HandleErrorCustom()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            var exception = exceptionHandlerFeature?.Error;

            // Ne devrait jamais se produire
            if (exception == null)
            {
                // 520 - Unknown Error
                return StatusCode(520);
            }

            // On enrichi l'exception des informations de la Request source


            // On informe l'appelant
            var errorMessage = _exceptionHandlersProvider
                        .GetHandler(exception.GetType())
                        .HandleException(exception);
            return StatusCode(errorMessage.StatusCode,errorMessage.Message);
        }
    }
}