using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccessor _userAccessor;

        public AccountController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        [HttpGet(Name = "GetProfile")]
        public string Get()
        {
            var username = _userAccessor.GetUserName();
            return username;
        }
    }
}
