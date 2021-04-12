using DevFreela.API.Models;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
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

        public UsersController(IUserService services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _services.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel createUser)
        {
            var id = _services.Create(createUser);

            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUser);
        }

        
        [HttpPut("{id}/login")]
        public IActionResult Delete(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }


    }
}
