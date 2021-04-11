using DevFreela.API.Models;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
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

        public ProjectsController(IProjectService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _services.GetAll(query);
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
        public IActionResult Post([FromBody] CreateProjectInputModel createProject)
        {
            if(createProject.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = _services.Create(createProject);

            return CreatedAtAction(
                nameof(GetById),
                new { id = id, },
                createProject);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel updateProject)
        {

            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }

            _services.Update(updateProject);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult Post([FromBody] CreateCommentInputModel createComment)
        {
            _services.CreateComment(createComment);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _services.Start(id);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _services.Finish(id);
            return NoContent();
        }
    }
}
