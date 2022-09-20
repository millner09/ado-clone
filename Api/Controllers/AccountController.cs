using Application.Interfaces;
using Application.Users;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMediator mediator, ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetProfile")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var user = await _mediator.Send(new Get.Query());
                return Ok(user);
            }
            catch (Exception e)
            {
                return Error(_logger, e);
            }
        }
    }
}
