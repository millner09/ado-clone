using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController : ControllerBase
    {
        protected IActionResult Error(ILogger logger, Exception e)
        {
            var exp = e;
            while (exp is not null)
            {
                logger.LogError(exp.Message);
                exp = exp.InnerException;
            }
            return Problem("Something went wrong...");
        }
    }
}
