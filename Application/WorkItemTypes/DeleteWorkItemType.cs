using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WorkItemTypes
{
    public class DeleteWorkItemType
    {
       public class Command : IRequest
        {
            public Command(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var workItemType = await _context.WorkItemTypes.FindAsync(request.Id);

                if (workItemType is null)
                    return Unit.Value;

                _context.WorkItemTypes.Remove(workItemType);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
