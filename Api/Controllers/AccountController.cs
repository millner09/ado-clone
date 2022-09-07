using Application.Interfaces;
using Application.Users;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProfile")]
        public async Task<AppUser> Get()
        {
            var user = await _mediator.Send(new Get.Query());
            return user;
        }
    }
}
