using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = new GetUserQuery(id);
            var user = await _mediator.Send(result);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand createUser)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                
                return BadRequest(messages);
            }

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
