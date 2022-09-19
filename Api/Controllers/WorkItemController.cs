using Application.WorkItems;
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
    public class WorkItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public WorkItemController(IMediator mediator, ILogger<WorkItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<GetWorkItems.QueryResult>> GetWorkItems()
        {
            var result = await _mediator.Send(new GetWorkItems.Query());

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkItemById(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetWorkItemById.Query(id));

                if (result is null)
                    return NotFound();

                return Ok(result);
            }
            catch(Exception e)
            {
               return Error(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkItem([FromBody] CreateWorkItem.Command command)
        {
            try
            {
                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception e)
            {
                return Error(e);
            }

        }


        private IActionResult Error(Exception e)
        {
            var exp = e;
            while(exp is not null)
            {
                _logger.LogError(exp.Message);
                exp = exp.InnerException;
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong...");
        }
    }
}
