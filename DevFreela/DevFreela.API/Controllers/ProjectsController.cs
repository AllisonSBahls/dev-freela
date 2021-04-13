using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _services;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService services, IMediator mediator)
        {
            _services = services;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _mediator.Send(query);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _services.GetById(id);

            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand createProject)
        {
            if(createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            //var id = _services.Create(createProject);

            var id = await _mediator.Send(createProject);
            return CreatedAtAction(
                nameof(GetById),
                new { id = id, },
                createProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand updateProject)
        {

            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }

            await _mediator.Send(updateProject);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateProjectCommand createComment)
        {
            await _mediator.Send(createComment);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
