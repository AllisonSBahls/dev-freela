using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _services;
        private readonly IMediator _mediator;

        public UsersController(IUserService services, IMediator mediator)
        {
            _services = services;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _services.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand createUser)
        {
            var id = await _mediator.Send(createUser);

            return CreatedAtAction(nameof(GetById), new { id = id }, createUser);
        }

        
        [HttpPut("{id}/login")]
        public IActionResult Delete(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }


    }
}
