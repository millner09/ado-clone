using Application.WorkItemTypes;
using MediatR;
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
    public class WorkItemTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkItemTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateWorkItemType(CreateWorkItemType.Command command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
