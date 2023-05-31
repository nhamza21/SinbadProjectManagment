using Microsoft.AspNetCore.Mvc;
using SinbadProjectManagement.Application.Projects.Commands.Create;
using SinbadProjectManagement.Application.Projects.Commands.Update;
using SinbadProjectManagement.Application.Projects.Queries;

namespace SinbadProjectManagement.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProjectsController : SinbadBaseController
    {
        private ILogger<ProjectsController> _logger;

        public ProjectsController(ILogger<ProjectsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await Sender.Send(new GetAllProjectsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            return Ok(await Sender.Send(new GetProjectQuery {Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(CreateProjectCommand request)
        {
            var code = await Sender.Send(request);
            return Ok(code);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectCommand request)
        {
            await Sender.Send(request);
            return NoContent();
        }


    }
}