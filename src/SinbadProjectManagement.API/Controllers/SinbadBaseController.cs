using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SinbadProjectManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinbadBaseController : ControllerBase
    {
        private IMediator _sender;
        protected IMediator Sender => _sender ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}