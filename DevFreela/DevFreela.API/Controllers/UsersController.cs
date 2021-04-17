using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand createUser)
        {
            var id = await _mediator.Send(createUser);

            return CreatedAtAction(nameof(GetById), new { id = id }, createUser);
        }

        
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([FromBody] LoginUserCommand login)
        {
            var loginUserViewModel = await _mediator.Send(login);
            if (loginUserViewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUserViewModel);
        }


    }
}
