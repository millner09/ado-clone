using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WorkItems
{
    public class DeleteWorkItem
    {
        public class Command : IRequest {
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
                var workItem = await _context.WorkItems.FindAsync(request.Id);
                if(workItem is not null)
                {
                    _context.Remove(workItem);
                    await _context.SaveChangesAsync();
                }

                return Unit.Value;
            }
        }
    }
}
