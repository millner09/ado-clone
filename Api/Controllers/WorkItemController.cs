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

        public WorkItemController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<GetWorkItems.QueryResult>> GetWorkItems()
        {
            var result = await _mediator.Send(new GetWorkItems.Query());

            return result;
        }

        [HttpGet("{id}")]
        public async Task<GetWorkItemById.QueryResult> GetWorkItemById(Guid id)
        {
            var result = await _mediator.Send(new GetWorkItemById.Query(id));

            return result;
        }
    }
}
