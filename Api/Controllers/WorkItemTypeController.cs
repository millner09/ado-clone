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
    public class WorkItemTypeController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WorkItemTypeController> _logger;

        public WorkItemTypeController(IMediator mediator, ILogger<WorkItemTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> CreateWorkItemType(CreateWorkItemType.Command command)
        {
            try
            {
                var res = await _mediator.Send(command);
                return Ok(res);
            }
            catch (Exception e)
            {
                return Error(_logger, e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkItemTypes()
        {
            try
            {
                var res = await _mediator.Send(new GetWorkItemTypes.Query());
                return Ok(res);
            }
            catch (Exception e)
            {
                return Error(_logger, e);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkItemTypeById(Guid id)
        {
            try
            {
                var res = await _mediator.Send(new GetWorkItemTypeById.Query(id));
                if (res is null)
                    return NotFound();
                
                return Ok(res); 
            }
            catch (Exception e)
            {
                return Error(_logger, e);
            }
        }
    }
}
