using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProject;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var result = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(result);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = new GetProjectQuery(id);
            var project = await _mediator.Send(result);
            return Ok(project);
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand createProject)
        {
            //var id = _services.Create(createProject);

            var id = await _mediator.Send(createProject);
            return CreatedAtAction(
                nameof(GetById),
                new { id = id, },
                createProject);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand updateProject)
        {

            await _mediator.Send(updateProject);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand createComment)
        {
            await _mediator.Send(createComment);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Finish(int id, [FromBody] FinishProjectCommand command)
        {
            command.Id = id;
            var result  = await _mediator.Send(command);
            await _mediator.Send(result);
            return Accepted();
        }
    }
}
